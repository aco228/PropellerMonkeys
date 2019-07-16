using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PropellerMonkeys.DesktopClient.Code;
using PropellerMonkeys.DesktopClient.Models;

namespace PropellerMonkeys.DesktopClient.Controllers
{
  public class HomeController : Controller
  {

    public HomeController(IHostingEnvironment hostEnvironment)
    {
      Program.Hosting = hostEnvironment;
      Program.InitialData = new InitialData();
    }

    public IActionResult Index()
    {
      // check if there are initial data
      if (string.IsNullOrEmpty(Program.InitialData["username"]) || string.IsNullOrEmpty(Program.InitialData["username"]))
      {
        ViewBag.ErrorMessage = "No initial data " + Program.Hosting.WebRootPath;
        return View("~/Views/Error.cshtml");
      }

      ViewBag.Username = Program.InitialData["username"];
      ViewBag.Password = Program.InitialData["password"];
      return View();
    }

  }
}
