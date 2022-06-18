using GraphChecker.Models;

namespace GraphChecker.Checkers.Elements
{
    internal class CheckActualNodeType : BaseGraphCheckElement
    {
        public CheckActualNodeType(Tree tree) : base(tree) { }

        public override TreeStatusCodes Validate()
        {
            List<TreeStatusCodes> errCodes = Tree.Nodes
                .Select(IsValidNode)
                .Where(sc => sc != TreeStatusCodes.OK)
                .ToList();

            if (errCodes.Count > 0)
            {
                return errCodes.First();
            }
            return TreeStatusCodes.OK;
        }

        private static TreeStatusCodes IsValidNode(Node node)
        {
            return node.NodeType switch
            {
                NodeType.ROOT => TreeStatusCodes.OK,
                NodeType.NORMAL => (node.Children?.Count ?? 0) > 0 ? TreeStatusCodes.OK : TreeStatusCodes.ERR_LEAF_NOT_FOUND,
                NodeType.LEAF => (node.Children?.Count ?? 1) == 0 ? TreeStatusCodes.OK : TreeStatusCodes.ERR_LEAF_HAS_CHILD,
                NodeType.UNDEF => TreeStatusCodes.ERR_UNKNOW_TYPE,
                _ => TreeStatusCodes.ERR_UNKNOW_TYPE,
            };
        }
    }
}
