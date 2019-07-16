using PropellerMonkeys.Core.SocketsModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerMonkeys.Client.Code.Workers
{
  public class PingWorker : WorkerBase
  {
    public PingWorker() : base("main", "ping", 15000)
    {
    }

    public override void OnLoop()
    {
      Program.Client.SendModel(new PingSocketModel()
      {
        Balance = Program.Browser.GetCurrentBalance()
      }
      .Prepare());
    }
  }
}
