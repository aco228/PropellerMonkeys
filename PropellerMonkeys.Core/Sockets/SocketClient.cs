using PropellerMonkeys.Sockets.Core;
using PropellerMonkeys.Sockets.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerMonkeys.Core.Sockets
{
  public abstract class SocketClient : ClientBase
  {
    protected override bool KeepConnectionInSeparateThread => true;

    public SocketClient(string ip, string port, string username) : base(ip, port, username){ }

  }
}
