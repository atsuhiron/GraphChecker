// See https://aka.ms/new-console-template for more information
var fileName = "../../../Samples/valid_nodes.json";
var graphChecker = new GraphChecker.GraphChecker(fileName);

var sc = graphChecker.Run();
Console.WriteLine(sc);

