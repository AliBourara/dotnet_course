using WeddingPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace WeddingPlanner.Controllers;

public class WeddingsController : Controller

{
    private readonly MyContext _context;
    public WeddingsController(MyContext context)
    {
        _context = context;
    }
        //----------------------------------------------------Weddings----------------------------------------------------------------------->
    [HttpGet("weddings/new")]
    public IActionResult AddWedding()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("LogReg", "Users");
        }
        return View();
    }
    [HttpPost("weddings/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newWedding);
            _context.SaveChanges();

            return RedirectToAction("ShowWedding", "Weddings", new
            {
                weddingId = newWedding.WeddingId
            });
        }
        return View("AddWedding");
    }
    [HttpPost("weddings/destroy")]
    public IActionResult DeleteWedding(int weddingId)
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("LogReg", "Users");
        }
        Wedding? DeleteWedding = _context.Weddings.FirstOrDefault(s => s.WeddingId == weddingId);

        // 1 - Delete
        _context.Weddings.Remove(DeleteWedding);
        // 2 - Save
        _context.SaveChanges();
        return RedirectToAction("Dashboard","Users");
    }

    [HttpGet("weddings/{weddingId}")]
    public IActionResult ShowWedding(int weddingId)
    {
        Wedding? OneWedding = _context.Weddings.Include(wedding => wedding.WeddingParticipation)
        .ThenInclude(p => p.Participant)
        .FirstOrDefault(wedding => wedding.WeddingId == weddingId);
        return View(OneWedding);
    }
}