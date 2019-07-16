using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PropellerMonkeys.WebServer.Models;
using PropellerMonkeys.WebServer.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropellerMonkeys.WebServer.Controllers
{
  public class ConsoleController : Controller
  {
    public static readonly object LockObj = new object();
    public static IHubContext<ConsoleHub> HubContext;
    public static List<ConsoleModel> ConsoleData = new List<ConsoleModel>();
    
    public ConsoleController(IHubContext<ConsoleHub> hubContext)
    {
      HubContext = hubContext;
    }

    public static void ServerNewLine(string line)
    {
      lock(LockObj)
      {
        var entry = new ConsoleModel() { Text = line };
        ConsoleData.Add(entry);
        if (ConsoleData.Count > 1000)
          ConsoleData.RemoveRange(1000, ConsoleData.Count - 1);
        HubContext?.Clients.All.SendAsync("update", entry);
      }
    }


    public IActionResult LoadPrevious()
    {
      return this.Json(ConsoleData);
    }

    public IActionResult Index()
    {
      return View("~/Views/Console.cshtml");
    }

  }
}
