using GraphChecker.Models;

namespace GraphChecker.Checkers.Elements
{
    public class CheckNoLoop : BaseGraphCheckElement
    {
        public CheckNoLoop(Tree tree) : base(tree) { }

        public override TreeStatusCodes Validate()
        {
            var sortResult = TryTopologicalSort(Tree.Nodes);

            if (sortResult.Item1)
            {
                return TreeStatusCodes.OK;
            } 
            else
            {
                return TreeStatusCodes.ERR_LOOP;
            }
        }

        public static (bool, List<Node>) TryTopologicalSort(List<Node> nodes)
        {
            int initLength = nodes.Count;

            Node? root = nodes.Find(n => n.NodeType == NodeType.ROOT);
            if (root == null)
            {
                return (false, new List<Node> { });
            }

            nodes.Remove(root);

            // Topological sorted list
            List<Node> sorted = new() {};
            // List of nodes with no incoming edge
            List<Node> sources = new() { root };

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
                    nodes.Remove(childNode);

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
