using GraphChecker.Models;

namespace GraphChecker.Checkers.Elements
{
    public class CheckUniqueNode : BaseGraphCheckElement
    {
        public CheckUniqueNode(Tree tree) : base(tree) { }

        public override TreeStatusCodes Validate()
        {
            int nodeNum = Tree.Nodes.Count;
            List<string> nonNullNodeNames = Tree.Nodes
                .Select(node => node.Name ?? string.Empty)
                .Where(name => !string.IsNullOrEmpty(name))
                .ToList();

            if (nonNullNodeNames.Count != nodeNum)
            {
                return TreeStatusCodes.ERR_NULL_NODE_NAME;
            }

            var uniqueNames = new HashSet<string>(nonNullNodeNames);
            if (uniqueNames.Count != nodeNum)
            {
                return TreeStatusCodes.ERR_DUP_NODE_NAME;
            }

            return TreeStatusCodes.OK;
        }
    }
}
