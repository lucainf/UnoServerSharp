using System;
using WebSocketSharp;
using WebSocketSharp.Server;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Starting the server...");
List<Player> players = new();
var ws = new WebSocketServer(8080);
ws.Start();
ws.AddWebSocketService<Server>("/");
Console.WriteLine("Press ESC to quit.");

var charTTY = Console.ReadKey(true);
if (charTTY.Key == ConsoleKey.Escape) {
    ws.Stop();
}
