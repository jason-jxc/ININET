using ININET;
using ININET.Model;

var parser = new ININETFileParser();
var Yparser = new ININETStringParser();

ININETData data = parser.ReadFile("configuration.ini");


string useFullScreenStr = data["UI"]["fullscreen"];
// useFullScreenStr contains "true"
bool useFullScreen = bool.Parse(useFullScreenStr);

Console.WriteLine("UI-fullscreen={0}",useFullScreenStr);

Console.ReadLine();