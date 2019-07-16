using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerMonkeys.Sockets.Core
{
  [Serializable()]
  public class SocketRegistrationModel : SocketModelBase
  {
    public override SocketDistributionModelType Type => SocketDistributionModelType.LOGIN;

    public string Username { get; set; } = string.Empty;
    public Guid Guid { get; set; } = Guid.NewGuid();

  }
}
