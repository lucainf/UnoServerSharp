using System;
using WebSocketSharp;
using WebSocketSharp.Server;

public class Server: WebSocketBehavior {
    List<Game> Gamelist = new();
    protected override void OnMessage (MessageEventArgs e) {
        Send ("ciaobro");
    }
}