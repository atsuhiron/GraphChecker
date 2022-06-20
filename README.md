# GraphChecker
Check a graph structure descripted by json file.  
The program verifies that the given graph is a directed acyclic graph and has a single root node.

For example, the graph in the figure below satisfies this condition. (The red node represents a branching condition, so think of it as paired with the blue node immediately preceding it.)  
![Sub types of star](https://github.com/atsuhiron/GraphChecker/blob/main/GraphChecker/GraphChecker/img/star_category.en.png)

# Usage
```C#
var fileName = "you_graph.json";
var graphChecker = new GraphChecker.Checkers.SRDAGChecker(fileName);

var statusCode = graphChecker.Run();
Console.WriteLine(statusCode);
```

If your graph is valid, it will show as `OK`. If not, an error code will be displayed.  
See below for error codes.

## Error code list
- `ERR_CHILD_NOT_FOUND`  
A root or normal node without a child nodes is found.

- `ERR_LEAF_HAS_CHILD`  
A leaf node has child node.

- `ERR_UNKNOW_TYPE`  
Unknown node type is found.

- `ERR_ROOT_NOT_FOUND`  
A root node is not found.

- `ERR_MULTI_ROOT`  
Multiple root objects are found.

- `ERR_NULL_NODE_NAME`  
A node with a null name is found.

- `ERR_DUP_NODE_NAME`  
Duplicate node names.

- `ERR_NULL_CHILD_NAME`  
A child with a null name is found.

- `ERR_DUP_CHILD_NAME`  
Duplicate child node names in a node.

- `ERR_ISOLATED`  
There is isolated nodes.

- `ERR_LOOP`  
There is loops.

# Sample
For a sample of JSON, [see here](https://github.com/atsuhiron/GraphChecker/tree/main/GraphChecker/GraphChecker/Samples).