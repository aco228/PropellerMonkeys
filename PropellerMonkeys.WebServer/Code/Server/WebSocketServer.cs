using PropellerMonkeys.Core.Sockets;
using PropellerMonkeys.Sockets.Core;
using PropellerMonkeys.Sockets.Core.Base;
using PropellerMonkeys.WebServer.Code.Server;
using PropellerMonkeys.WebServer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropellerMonkeys.WebServer.Code
{
  public class WebSocketServer : SocketServer
  {
    protected override bool KeepConnectionInSeparateThread => true;
    public Dictionary<string, ServerClient> Clients = new Dictionary<string, ServerClient>();

    public WebSocketServer()
    {
      this.Console.OnNewLine = OnNewServerMessage;
    }

    public void OnNewServerMessage(string line)
    {
      ConsoleController.ServerNewLine(line);
    }

    public override void OnClientConnected(string identifier)
    {
      if (Clients.ContainsKey(identifier))
        Clients.Add(identifier, new ServerClient() { ID = identifier });

    }

    public override void OnClientDisconnected(string identifier)
    {
      if (Clients.ContainsKey(identifier))
        Clients.Remove(identifier);
    }

    public override void OnReceiveFromClient(SocketDistributionModel data, SocketObject socket)
    {
      throw new NotImplementedException();
    }
  }
}
