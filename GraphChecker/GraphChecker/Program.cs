var fileName = "../../../Samples/valid_nodes.json";
var graphChecker = new GraphChecker.GraphChecker(fileName);

var statusCode = graphChecker.Run();
Console.WriteLine(statusCode);
