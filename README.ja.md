# GraphChecker
Json ファイルに記載されたグラフ構造をチェックします。  
このプログラムでは有向非循環グラフで、かつルートノードが一つであることを検証します。

例えば、以下の図で示したグラフはこの条件を満たしています。（赤いノードは条件分岐を表しているので、その直前の青いノードとセットになっていると考えてください。）  
![Sub types of star](https://github.com/atsuhiron/GraphChecker/blob/main/GraphChecker/GraphChecker/img/star_category.ja.png)

# Usage
```C#
var fileName = "you_graph.json";
var graphChecker = new GraphChecker.Checkers.SRDAGChecker(fileName);

var statusCode = graphChecker.Run();
Console.WriteLine(statusCode);
```

もし、グラフが有効であれば、`OK` のように表示されます。  
そうでない場合、エラーコードが表示されます。エラーコードについては以下を参照してください。


## Error code list
- `ERR_CHILD_NOT_FOUND`  
ルートノードや通常ノードに、子ノードがない。

- `ERR_LEAF_HAS_CHILD`  
葉ノードに子ノードがある。

- `ERR_UNKNOW_TYPE`  
不明なタイプのノードがある。

- `ERR_ROOT_NOT_FOUND`  
ルートノードがない。

- `ERR_MULTI_ROOT`  
ルートノードが複数ある。

- `ERR_NULL_NODE_NAME`  
ノード名が `null` になっている。

- `ERR_DUP_NODE_NAME`  
ノード名が重複している。

- `ERR_NULL_CHILD_NAME`  
あるノードが持つ子ノードの名前が `null` になっている。

- `ERR_DUP_CHILD_NAME`  
あるノードが持つ子ノードの名前が 重複している。

- `ERR_ISOLATED`  
孤立したノードがある。

- `ERR_LOOP`  
ループがある。

# Sample
JSON のサンプルについては[こちら](https://github.com/atsuhiron/GraphChecker/tree/main/GraphChecker/GraphChecker/Samples)を参照してください。