using Craftshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Craftshop.Controllers;

public class UsersController : Controller

{
    private readonly CraftShopContext _context;
    public UsersController(CraftShopContext context)
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
        return RedirectToAction("Dashboard");
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
                HttpContext.Session.SetString("username", newUser.Username);
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
            return RedirectToAction("LogReg","Users");
        }
        int? userId = (int)HttpContext.Session.GetInt32("userId");
        User? user = _context.Users.FirstOrDefault(u => u.UserId == userId);
        int ItemSold = _context.Orders
                            .Include(order => order.Craft)
                            .Where(order => order.Craft.UserId == userId)
                            .Sum(order => order.Quantity);
                            
        return View(user);
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
                // Initialize hasher object
                var hasher = new PasswordHasher<LoginUser>();

                // verify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword(loginUser, userFromDb.Password, loginUser.LoginPassword);

                // result can be compared to 0 for failure
                if (result == 0)
                {
                    // handle failure (this should be similar to how "existing email" is handled)
                    ModelState.AddModelError("LoginPassword", "Wrong Password !");
                    return View("LogReg");
                }
                else
                {
                    HttpContext.Session.SetInt32("userId", userFromDb.UserId);
                    HttpContext.Session.SetString("username", userFromDb.Username);
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
}