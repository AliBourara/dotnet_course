using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("LogReg","Users");
    }

    public IActionResult Privacy()
    {
        return View("LogReg","Users");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
