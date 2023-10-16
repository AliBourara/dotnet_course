using Craftshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Craftshop.Controllers;

public class CraftsController : Controller

{
    private readonly CraftShopContext _context;
    public CraftsController(CraftShopContext context)
    {
        _context = context;
    }
    [HttpGet("crafts/new")]
    public IActionResult SellCraft()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("LogReg","Users");
        }
        return View();
    }
    [HttpPost("crafts/create")]
    public IActionResult CreateCraft(Craft newCraft)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newCraft);
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

