using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PropellerMonkeys.Client.Code;
using PropellerMonkeys.Client.Code.Workers;
using PropellerMonkeys.Client.Web;
using PropellerMonkeys.Core.Sockets;
using System;
using System.Threading;

namespace PropellerMonkeys.Client
{
  public static class Program
  {
    public static InitialData InitialData = null;
    public static Browser Browser = null;
    public static ConsoleSocketClient Client = null;
    public static WorkerManager WorkerManager = null;

    static void Main(string[] args)
    {
      InitialData = new InitialData();
      if(InitialData.HasError)
      {
        Console.ReadKey();
        return;
      }

      Client = new ConsoleSocketClient();
      Browser = new Browser();

      WorkerManager = new WorkerManager();
      new BrowserReloadWorker();
      new PingWorker();

      Console.ReadKey();
    }

  }
}
