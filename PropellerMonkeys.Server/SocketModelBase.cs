using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerMonkeys.Sockets.Core
{
  [Serializable()]
  public class SocketModelBase
  {
    public virtual SocketDistributionModelType Type { get; } = SocketDistributionModelType.DEFAULT;
  }
}
