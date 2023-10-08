using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;
namespace RandomPasscode.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static int NumberOfPasscode = 0;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpPost("/generate")]
    public IActionResult Generate()
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        char[] randomString = new char[14];
        Random rand = new Random();
        for (int i = 0; i < 14; i++)
        {
            randomString[i] = chars[rand.Next(chars.Length)];
        }
        string newString = new String(randomString);
        HttpContext.Session.SetInt32("numberOfPasscode", NumberOfPasscode);
        HttpContext.Session.SetString("RandCode", newString);
        return RedirectToAction("Index");
    }

    public IActionResult Index()
    {
        // if (HttpContext.Session.GetString("numberOfPasscode") == null)
        // {
        //     return RedirectToAction("Index");
        // }
        if (HttpContext.Session.GetString("RandCode") == null)
        {
             Generate();
        }
       
        NumberOfPasscode += 1;
        HttpContext.Session.SetInt32("numberOfPasscode", NumberOfPasscode);
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
