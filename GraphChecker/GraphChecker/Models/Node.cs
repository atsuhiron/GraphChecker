namespace GraphChecker.Models
{
    public class Node : IEquatable<Node>
    {
        public string? Name { get; set; }

        public string? DisplayName { get; set; }

        public List<NodeKey>? Children { get; set; }

        public NodeType NodeType { get; set; }

        public List<string> GetChildNames()
        {
            if (Children == null) return new List<string>();

            return Children
                .Select(child => child.NodeName ?? string.Empty)
                .Where(name => !string.IsNullOrEmpty(name))
                .ToList();
        }

        public bool Equals(Node? other)
        {
            if (other == null) return false;

            return this.GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            return new { V1 = Name ?? string.Empty }.GetHashCode();
        }
    }
}
