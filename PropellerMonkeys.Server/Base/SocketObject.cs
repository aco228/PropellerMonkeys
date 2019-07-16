using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace PropellerMonkeys.Sockets.Core.Base
{
  public class SocketObject
  {
    public string Identifier { get; set; } = string.Empty;
    public Socket Socket { get; set; } = null;

    public SocketObject(Socket socket) => this.Socket = socket;
    public SocketObject(Socket socket, string identifier)
    {
      this.Socket = socket;
      this.Identifier = identifier;
    }
  }
}
