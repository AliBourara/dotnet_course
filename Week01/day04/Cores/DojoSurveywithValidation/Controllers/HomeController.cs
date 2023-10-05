using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveywithValidation.Models;

namespace DojoSurveywithValidation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("/create")]
    public IActionResult CreateForm(Dojo dojo)
    {
        if (ModelState.IsValid)
        {
            
            return RedirectToAction("Result");
        }
        return View("Index");
    }

    public IActionResult Result()
    {
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
