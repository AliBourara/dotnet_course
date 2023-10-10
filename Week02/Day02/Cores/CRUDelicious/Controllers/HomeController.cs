using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private MyContext _context; 
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context) 
    {
        _logger = logger;
        _context = context; 
    }

    public IActionResult Index()
    {
        List<Dish> AllDishes = _context.Dishes.ToList();
        return View(AllDishes);
    }
    [HttpGet("Dishes/{dishId}")]
    public IActionResult Edit(Dish ShowedDish)
    {
        Dish? DishToView = _context.Dishes.FirstOrDefault(q => q.DishId == ShowedDish.DishId);
        DishToView.Name = ShowedDish.Name;
        DishToView.Chef = ShowedDish.Chef;
        DishToView.Tastiness = ShowedDish.Tastiness;
        DishToView.Calories = ShowedDish.Calories;
        DishToView.Description = ShowedDish.Description;
        
        return View("ShowOne",DishToView);
    }
    [HttpPost("Dishes/create")]
    public IActionResult CreateSong(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            // 1 - Add 
            _context.Add(newDish);
            // 2 - Save
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("Privacy");
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
