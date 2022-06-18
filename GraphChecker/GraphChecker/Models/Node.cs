namespace GraphChecker.Models
{
    public class Node
    {
        public string? Name { get; set; }

        public string? DisplayName { get; set; }

        public List<NodeKey>? Children { get; set; }

        public NodeType NodeType { get; set; }
    }
}
