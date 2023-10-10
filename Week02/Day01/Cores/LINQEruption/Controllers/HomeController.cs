using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LINQEruption.Models;

namespace LINQEruption.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //Use LINQ to find the first eruption that is in Chile and print the result.
        List<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Location == "Chile").Take(1).ToList();
        ViewBag.stratovolcanoEruptions = stratovolcanoEruptions;
        //Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
        bool HawaiianIs = eruptions.Any(a => a.Location == "Hawaiian Is");
        ViewBag.HawaiianIs = HawaiianIs;
        //Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
        List<Eruption> After1900NewZealand = eruptions.Where(a=>a.Location == "New Zealand").Where(b=>b.Year > 1900).Take(1).ToList();
        ViewBag.After1900NewZealand = After1900NewZealand;
        //Find all eruptions where the volcano's elevation is over 2000m and print them.
        List<Eruption> After2000m = eruptions.Where(a=>a.ElevationInMeters > 2000).ToList();
        ViewBag.After2000m = After2000m;
        //Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.
        List<Eruption> StartWithL = eruptions.Where(a=>a.Volcano.StartsWith("L")).ToList();
        int NumberOfVolcano = eruptions.Count(b=>b.Volcano.StartsWith("L"));
        ViewBag.NumberOfVolcano = NumberOfVolcano;
        ViewBag.StartWithL = StartWithL;
        //Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
        int HighestElevation = eruptions.Max(m=> m.ElevationInMeters);
        ViewBag.HighestElevation = HighestElevation ;
        //Use the highest elevation variable to find a print the name of the Volcano with that elevation.
        Eruption ? Elevated  = eruptions.FirstOrDefault(e => e.ElevationInMeters == HighestElevation);
        ViewBag.Elevated = Elevated;
        //Print all Volcano names alphabetically.
        List<string> VolcanoName = eruptions.Select(j=>j.Volcano).ToList();
        ViewBag.VolcanoName = VolcanoName;
        //Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
        List<string> VolcanoNameAfter1000 = eruptions.Where(s=>s.Year > 1000).Select(j=>j.Volcano).ToList();
        ViewBag.VolcanoNameAfter1000 = VolcanoNameAfter1000;
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
