namespace GraphChecker.Models
{
    public class Tree
    {
        public List<Node> Nodes { get; set; }

        public string RootName { get; set; }

        public Tree(List<Node> nodes, string rootName)
        {
            Nodes = nodes;
            RootName = rootName;
        }
    }
}
