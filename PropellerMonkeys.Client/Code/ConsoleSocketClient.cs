using PropellerMonkeys.Core.Sockets;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerMonkeys.Client.Code
{
  public class ConsoleSocketClient : SocketClient
  {
    public ConsoleSocketClient()
      : base(Program.InitialData["ip"], Program.InitialData["port"], Program.InitialData["username"])
    { }

    protected override void OnConnection()
    {
      throw new NotImplementedException();
    }

    protected override void OnDisconnection()
    {
      throw new NotImplementedException();
    }
  }
}
