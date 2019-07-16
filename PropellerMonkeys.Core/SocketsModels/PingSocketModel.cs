using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerMonkeys.Core.SocketsModels
{
  [Serializable()]
  public class PingSocketModel : SocketsModelBase
  {
    public override SocketsModelType Type => SocketsModelType.Default;
    public string Balance { get; set; } = string.Empty;
  }
}
