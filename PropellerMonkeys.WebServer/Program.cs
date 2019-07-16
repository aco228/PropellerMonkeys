using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PropellerMonkeys.Core.Sockets;
using PropellerMonkeys.WebServer.Code;

namespace PropellerMonkeys.WebServer
{
  public class Program
  {

    public static WebSocketServer Server = null;

    public static void Main(string[] args)
    {
      Server = new WebSocketServer();
      CreateWebHostBuilder(args)
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseIISIntegration()
        .Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
  }
}
