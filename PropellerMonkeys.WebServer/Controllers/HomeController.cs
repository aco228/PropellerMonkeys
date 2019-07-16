using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PropellerMonkeys.WebServer.Models;
using PropellerMonkeys.WebServer.SignalR;

namespace PropellerMonkeys.WebServer.Controllers
{
  public class HomeController : Controller
  {
    public static IHubContext<ConsoleHub> HubContext;

    public HomeController(IHubContext<ConsoleHub> hubContext)
    {
      HubContext = hubContext;
    }


    public IActionResult Index()
    {
      return View("~/Views/Index.cshtml");
    }

    public IActionResult TestConsole(string command)
    {
      HubContext.Clients.All.SendAsync("Command", command);
      return this.Content("OK");
    }
  }
}
