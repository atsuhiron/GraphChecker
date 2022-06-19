var fileName = "../../../Samples/valid_nodes.json";
var graphChecker = new GraphChecker.Checkers.SRDAGChecker(fileName);

var statusCode = graphChecker.Run();
Console.WriteLine(statusCode);
