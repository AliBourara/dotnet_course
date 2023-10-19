using WeddingPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace WeddingPlanner.Controllers;

public class UsersController : Controller

{
    private readonly MyContext _context;
    public UsersController(MyContext context)
    {
        _context = context;
    }
    [HttpGet("")]
    public IActionResult LogReg()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return View();
        }
        return RedirectToAction("Dashboard", "Users");
    }
    //-------------------- Register ---------------------

    [HttpPost("users/create")]
    public IActionResult Register(User newUser)
    {


        if (ModelState.IsValid)
        {
            // Email Exist ?
            if (_context.Users.Any(u => u.Email == newUser.Email))
            {
                // True
                ModelState.AddModelError("Email", "Email already in use .");
                return View("LogReg");
            }
            else
            {
                // False
                // 1 - Hash Password
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                // 2 - Add 
                _context.Add(newUser);
                // 3 - Save
                _context.SaveChanges();
                HttpContext.Session.SetInt32("userId", newUser.UserId);
                HttpContext.Session.SetString("Firstname", newUser.Firstname);
                // HttpContext.Session.
                return RedirectToAction("Dashboard");
            }
        }
        return View("LogReg");
    }
    //-----------------------Dashboard---------------------------
    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("LogReg", "Users");
        }
        int? userId = (int)HttpContext.Session.GetInt32("userId");
        User? user = _context.Users.FirstOrDefault(u => u.UserId == userId);
        List<Wedding> AllWeddingsWithCreator = _context.Weddings
        .Include(p => p.WeddingParticipation).ToList();
        AllWeddingsView allWeddingView = new()
        {
            AllWeddings = AllWeddingsWithCreator
        };
        return View(allWeddingView);
    }
    //-------------------- Login ---------------------
    [HttpPost("users/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid)
        {
            // User Registered ?
            User? userFromDb = _context.Users.FirstOrDefault(u => u.Email == loginUser.LoginEmail);
            if (userFromDb is null)
            {
                ModelState.AddModelError("LoginEmail", "Email dose not exist !");
                return View("LogReg");
            }
            else
            {
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(loginUser, userFromDb.Password, loginUser.LoginPassword);
                if (result == 0)
                {
                    ModelState.AddModelError("LoginPassword", "Wrong Password !");
                    return View("LogReg");
                }
                else
                {
                    HttpContext.Session.SetInt32("userId", userFromDb.UserId);
                    HttpContext.Session.SetString("Firstname", userFromDb.Firstname);
                    return RedirectToAction("Dashboard");
                }
            }
        }
        return View("LogReg");

    }

    //-------------------- Logout ---------------------

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("LogReg");
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

            return RedirectToAction("ShowWedding", "Users", new
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
        return RedirectToAction("Dashboard");
    }

    [HttpGet("weddings/{weddingId}")]
    public IActionResult ShowWedding(int weddingId)
    {
        Wedding? OneWedding = _context.Weddings.Include(wedding => wedding.WeddingParticipation)
        .ThenInclude(p => p.Participant)
        .FirstOrDefault(wedding => wedding.WeddingId == weddingId);
        return View(OneWedding);
    }

    //---------------------------------------------------------------Participate & UnParticipate---------------------------------------------------------->
    [HttpPost("participate/create")]
    public IActionResult Part(Participation newPart)
    {
        if (ModelState.IsValid)
        {
            // 1 - Add
            _context.Add(newPart);
            // 2 - Save
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        return RedirectToAction("Dashboard");
    }
    [HttpPost("participate/destroy")]
    public IActionResult UnPart(Participation PartToDelete)
    {
        if (ModelState.IsValid)
        {
            // 1 - Add
            _context.Remove(PartToDelete);
            // 2 - Save
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        return RedirectToAction("Dashboard");
    }


}