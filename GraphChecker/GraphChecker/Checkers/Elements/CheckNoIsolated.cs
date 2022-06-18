using GraphChecker.Models;

namespace GraphChecker.Checkers.Elements
{
    public class CheckNoIsolated : BaseGraphCheckElement
    {
        public CheckNoIsolated(Tree tree) : base(tree) { }

        public override TreeStatusCodes Validate()
        {
            List<string> nodeNamesExceptforRoot = Tree.Nodes
                .Where(node => node.NodeType != NodeType.ROOT)
                .Select(x => x.Name ?? string.Empty)
                .ToList();

            List<string> allChildNames = Tree.Nodes
                .SelectMany(
                    node => node.Children?
                        .Select(child => child.NodeName ?? string.Empty) ?? new List<string>())
                .ToList();

            bool isAllNodeChildOfAnother = nodeNamesExceptforRoot
                .All(nodeName => allChildNames.Contains(nodeName));

            foreach (string nodeName in nodeNamesExceptforRoot)
            {
                if (allChildNames.Contains(nodeName))
                {
                    isAllNodeChildOfAnother = true;
                } else
                {
                    isAllNodeChildOfAnother = false;
                }
            }

            if (isAllNodeChildOfAnother)
            {
                return TreeStatusCodes.OK;
            }
            return TreeStatusCodes.ERR_ISOLATED;
        }
    }
}
