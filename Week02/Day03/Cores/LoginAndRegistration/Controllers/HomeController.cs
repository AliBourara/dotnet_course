﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using LoginAndRegistration.Models;

namespace LoginAndRegistration.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    // This is already in your controller
    private readonly ILogger<HomeController> _logger;

    // here we can "inject" our context service into the constructor
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        // This becomes the name we use to reference our database
        _context = context;
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
                return View("Index");
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
                // HttpContext.Session.
                return RedirectToAction("Privacy");
            }
        }
        return View("Index");
    }
    public IActionResult Index()
    {
        return View();
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
                return View("Index");
            }
            else
            {
                // Initialize hasher object
                var hasher = new PasswordHasher<LoginUser>();

                // verify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword(loginUser, userFromDb.Password, loginUser.LoginPassword);

                // result can be compared to 0 for failure
                if (result == 0)
                {
                    // handle failure (this should be similar to how "existing email" is handled)
                    ModelState.AddModelError("LoginPassword", "Wrong Password !");
                    return View("Index");
                }
                else
                {
                    HttpContext.Session.SetInt32("userId", userFromDb.UserId);
                    return RedirectToAction("Privacy");
                }
            }
        }
        return View("Index");

    }

    //-------------------- Logout ---------------------

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Index");
        }
        int? userId = (int)HttpContext.Session.GetInt32("userId");
        User? user = _context.Users.FirstOrDefault(u => u.UserId == userId);
        return View(user);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
