using GraphChecker.Models;

namespace GraphChecker.Checkers.Elements
{
    public abstract class BaseGraphCheckElement
    {
        protected Tree Tree { get; init; }

        protected BaseGraphCheckElement(Tree tree)
        {
            this.Tree = tree;
        }

        public abstract TreeStatusCodes Validate();
    }
}
