using GraphChecker.Models;

namespace GraphChecker.Checkers.Elements
{
    public class CheckUniqueChildren : BaseGraphCheckElement
    {
        public CheckUniqueChildren(Tree tree) : base(tree) { }

        public override TreeStatusCodes Validate()
        {
            List<Node> rootOrNormal = Tree.Nodes
                .Where(node => node.NodeType == NodeType.ROOT || node.NodeType == NodeType.NORMAL)
                .ToList();

            foreach(Node node in rootOrNormal)
            {
                var nodeStatus = DecisionChildrenNameStatus(node);
                if (nodeStatus != TreeStatusCodes.OK)
                {
                    return nodeStatus;
                }
            }
            return TreeStatusCodes.OK;
        }

        private static TreeStatusCodes DecisionChildrenNameStatus(Node node)
        {
            List<string?> childNames = node.Children?
                .Select(child => child.NodeName)
                .ToList() 
                ?? new List<string?>();

            List<string> nonNullChildNames = node.GetChildNames();

            if (childNames.Count != nonNullChildNames.Count)
            {
                return TreeStatusCodes.ERR_NULL_CHILD_NAME;
            }

            var uniqueChildNames = new HashSet<string>(nonNullChildNames);
            if (childNames.Count != uniqueChildNames.Count)
            {
                return TreeStatusCodes.ERR_DUP_CHILD_NAME;
            }
            return TreeStatusCodes.OK;
        }
    }
}
