namespace GraphChecker.Checkers
{
    public enum TreeStatusCodes
    {
        // Default status. It is expected to not to use.
        UNDEF,

        // Valid status.
        OK,

        // Invalid status. A root or normal node without a child nodes is found.
        ERR_CHILD_NOT_FOUND,

        // Invalid status. A leaf node has child node.
        ERR_LEAF_HAS_CHILD,

        // Invalid status. Unknown node type is found.
        ERR_UNKNOW_TYPE,

        // Invalid status. A root node is not found.
        ERR_ROOT_NOT_FOUND,

        // Invalid status. Multiple root objects are found.
        ERR_MULTI_ROOT,

        // Invalid status. A node with a null name is found.
        ERR_NULL_NODE_NAME,

        // Invalid status. Duplicate node names.
        ERR_DUP_NODE_NAME,

        // Invalid status. A child with a null name is found.
        ERR_NULL_CHILD_NAME,

        // Invalid status. Duplicate child node names in a node.
        ERR_DUP_CHILD_NAME,

        // Invalid status. There is isolated nodes.
        ERR_ISOLATED,

        // Invalid status. There is loops.
        ERR_LOOP
    }
}
