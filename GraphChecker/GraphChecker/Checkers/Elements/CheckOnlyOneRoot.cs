using GraphChecker.Models;

namespace GraphChecker.Checkers.Elements
{
    public class CheckOnlyOneRoot : BaseGraphCheckElement
    {
        public CheckOnlyOneRoot(Tree tree) : base(tree) { }

        public override TreeStatusCodes Validate()
        {
            int rootNum = Tree.Nodes.Where(node => node.NodeType == NodeType.ROOT).Count();

            return rootNum switch
            {
                0 => TreeStatusCodes.ERR_ROOT_NOT_FOUND,
                1 => TreeStatusCodes.OK,
                _ => TreeStatusCodes.ERR_MULTI_ROOT,
            };
        }
    }
}
