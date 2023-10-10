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
    public IActionResult Show(int dishId)
    {
        Dish? DishToView = _context.Dishes.FirstOrDefault(q => q.DishId == dishId);
        return View("ShowOne",DishToView);
    }
    [HttpGet("Dishes/{dishId}/edit")]
    public IActionResult Edit(int dishId)
    {
        Dish? DishToEdit = _context.Dishes.FirstOrDefault(q => q.DishId == dishId);
        return View(DishToEdit);
    }
    [HttpPost("")]
    public IActionResult UpdateDish(Dish editedDish)
    {
        Dish? DishToUpdate = _context.Dishes.FirstOrDefault(q => q.DishId == editedDish.DishId);
        if (ModelState.IsValid)
        {
            DishToUpdate.Name = editedDish.Name;
            DishToUpdate.Chef = editedDish.Chef;
            DishToUpdate.Calories = editedDish.Calories;
            DishToUpdate.Tastiness = editedDish.Tastiness;
            DishToUpdate.Description = editedDish.Description;
            DishToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("Edit", DishToUpdate);
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
    [HttpPost("Dishes/destroy")]
    public IActionResult DeleteDish(int dishId)
    {
        Dish? DishToDelete = _context.Dishes.FirstOrDefault(s => s.DishId == dishId);
        // 1 - Delete
        _context.Dishes.Remove(DishToDelete);
        // 2 - Save
        _context.SaveChanges();
        return RedirectToAction("Index");
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
