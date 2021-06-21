using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebIssueManagementApp.Models;

namespace WebIssueManagementApp.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      string user;
      bool authenticated;
      if (HttpContext.User.Identity.IsAuthenticated)
      {
        user = HttpContext.User.Identity.Name;
        authenticated = true;
      }
      else
      {
        user = "Not Logged In";
        authenticated = false;
      }

      ViewBag.user = user;
      ViewBag.authenticated = authenticated;

      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
