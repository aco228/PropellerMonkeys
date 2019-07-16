using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerMonkeys.Sockets.Core
{
  public static class SocketHelpers
  {
    public static SocketDistributionModel Instantiate(this SocketModelBase input) => new SocketDistributionModel(input, input.Type);
  }
}
