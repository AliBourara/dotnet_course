
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefNDishes.Controllers;

public class HomeController : Controller
{
    private MyContext _context; // 5 -
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context) //6 - 
    {
        _logger = logger;
        _context = context; // 7 - 
    }



    public IActionResult Index()
    {
        List<Chef> AllChefs = _context.Chefs.ToList();
        ViewBag.AllChefs = AllChefs;
        return View();
    }
    public IActionResult AddChef()
    {
        return View();
    }
    public IActionResult AddDish()
    {
        List<Chef> AllChefs = _context.Chefs.ToList();
        ViewBag.AllChefs = AllChefs;
        return View();
    }

    public IActionResult Diches()
    {
        List<Dish> AllDichesWithPoster = _context.Dishes.Include(p=>p.Poster).ToList();
        return View(AllDichesWithPoster);
    }
[HttpPost("Chefs/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if (ModelState.IsValid)
        {
            // 1 - Add 
            _context.Add(newChef);
            // 2 - Save
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("AddChef");
    }
    [HttpPost("dish/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            // 1-Add
            _context.Add(newDish);
            // 2-Save
            _context.SaveChanges();
            return RedirectToAction("Diches");
        }
        return View("AddDish");
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
