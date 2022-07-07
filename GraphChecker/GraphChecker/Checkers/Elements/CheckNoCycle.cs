using GraphChecker.Models;

namespace GraphChecker.Checkers.Elements
{
    public class CheckNoCycle : BaseGraphCheckElement
    {
        public CheckNoCycle(Tree tree) : base(tree) { }

        public override TreeStatusCodes Validate()
        {
            var sortResult = TryTopologicalSort(Tree.Nodes);

            if (sortResult.Item1)
            {
                return TreeStatusCodes.OK;
            } 
            else
            {
                return TreeStatusCodes.ERR_CYCLE;
            }
        }

        public static (bool, List<Node>) TryTopologicalSort(List<Node> nodes)
        {
            int initLength = nodes.Count;

            // Topological sorted list
            List<Node> sorted = new() {};

            // List of nodes with no incoming edge
            List<Node> sources = nodes.FindAll(n => n.NodeType == NodeType.ROOT);
            if (sources.Count == 0)
            {
                return (false, new List<Node> { });
            }

            foreach (Node source in sources)
            {
                nodes.Remove(source);
            }

            while (sources.Count > 0)
            {
                var node = sources.First();
                sources.Remove(node);
                sorted.Add(node);

                foreach (var childName in node.GetChildNames())
                {
                    var childNode = nodes.Find(_node => _node.Name == childName);
                    if (childNode == null)
                    {
                        return (false, new List<Node> { });
                    }
                    nodes.Remove(node);

                    if (CountParentWithTheChild(childNode, nodes) == 0)
                    {
                        sources.Add(childNode);
                    }
                }
            }

            bool isSuccess = initLength == sorted.Count;
            return (isSuccess, sorted);
        }

        private static int CountParentWithTheChild(Node child, List<Node> nodes)
        {
            if (child.Name == null)
            {
                return 0;
            }

            int count = 0;
            foreach (var node in nodes)
            {
                var childNames = node.GetChildNames();
                if (childNames.Contains(child.Name))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
