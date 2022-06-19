using System.Text.Json;
using System.Text.Json.Serialization;
using GraphChecker.Models;
using GraphChecker.Checkers.Elements;

namespace GraphChecker
{
    public class GraphChecker
    {
        public Tree Tree { get; init; }
        private List<BaseGraphCheckElement> CheckElements { get; init; }

        public GraphChecker(string fileName, JsonSerializerOptions? options = null)
        {
            options ??= new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter() }
            };

            var readRes = ReadFile(fileName, options);
            if (!readRes.Item1 || readRes.Item2 == null)
            {
                throw new JsonException("The format of json file is invalid: " + fileName);
            }

            this.Tree = readRes.Item2;
            CheckElements = GenCheckers(this.Tree);
        }

        public GraphChecker(Tree tree)
        {
            this.Tree = tree;
            CheckElements = GenCheckers(this.Tree);
        }

        public TreeStatusCodes Run()
        {
            foreach (var checkElement in CheckElements)
            {
                TreeStatusCodes sc = checkElement.Validate();
                if (sc != TreeStatusCodes.OK)
                {
                    return sc;
                }
            }

            return TreeStatusCodes.OK;
        }

        private static List<BaseGraphCheckElement> GenCheckers(Tree tree)
        {
            return new List<BaseGraphCheckElement>
            {
                new CheckActualNodeType(tree),
                new CheckOnlyOneRoot(tree),
                new CheckUniqueNode(tree),
                new CheckUniqueChildren(tree),
                new CheckNoIsolated(tree),
                new CheckNoLoop(tree)
            };
        }

        private static (bool, Tree?) ReadFile(string fileName, JsonSerializerOptions options)
        {
            using FileStream openStream = File.OpenRead(fileName);
            Tree? tree = JsonSerializer.Deserialize<Tree>(openStream, options);
            return (tree != null, tree);
        }
    }
}
