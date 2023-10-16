using WeddingPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace WeddingPlanner.Controllers;

public class WeddingController : Controller

{
    private readonly WeddingPlannerContext _context;
    public WeddingController(WeddingPlannerContext context)
    {
        _context = context;
    }
    [HttpGet("weddings/new")]
    public IActionResult Weddings()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("LogReg","Users");
        }
        return View();
    }
    [HttpPost("weddings/create")]
    public IActionResult CreateCraft(Wedding newWedding)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("Dashboard","Users");
        }
        return View("SellCraft");
    }
    [HttpGet("crafts")]
    public IActionResult ShopCrafts()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("LogReg","Users");
        }
        List<Craft> AllCrafts = _context.Crafts.Include(craft => craft.Owner).ToList();
        return View(AllCrafts);
    }

    [HttpGet("crafts/{craftId}")]
    public IActionResult ShowCraft(int craftId)
    {
        Craft OneCraft = _context.Crafts.Include(craft => craft.Owner).FirstOrDefault(craft => craft.CraftId == craftId);
        return View(OneCraft);
    }


}