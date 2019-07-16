using PropellerMonkeys.Sockets.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerMonkeys.Core.SocketsModels
{
  [Serializable()]
  public class SocketsModelBase : SocketModelBase
  {
    public virtual SocketsModelType Type { get; } = SocketsModelType.Default;
    public string Username { get; set; } = string.Empty;
  }
}
