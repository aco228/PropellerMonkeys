using PropellerMonkeys.Sockets.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerMonkeys.Core.Sockets
{
  public abstract class SocketServer : ServerBase
  {
    public SocketServer() : base(33228) { }

  }
}
