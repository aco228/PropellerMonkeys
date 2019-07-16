using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ElectronNET.API;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PropellerMonkeys.DesktopClient.Code;

namespace PropellerMonkeys.DesktopClient
{
  public class Program
  {
    public static IHostingEnvironment Hosting = null;
    public static InitialData InitialData = null;
    public static ElectronInitialize ElectronInitialize = null;
    
    public static void Main(string[] args)
    {
      Console.WriteLine("-------------------------> majku ti jebem " + System.IO.Directory.GetCurrentDirectory());
      CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
      WebHost.CreateDefaultBuilder(args)
        .UseElectron(args)
        .UseStartup<Startup>();
  }
}
