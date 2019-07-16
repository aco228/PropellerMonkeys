using PropellerMonkeys.Core.SocketsModels;
using PropellerMonkeys.Sockets.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerMonkeys.Client.Code
{
  public static class SocketsModelHelper
  {

    public static SocketDistributionModel Prepare(this SocketsModelBase input)
    {
      input.Username = Program.InitialData["username"];
      return input.Instantiate();
    }

  }
}
