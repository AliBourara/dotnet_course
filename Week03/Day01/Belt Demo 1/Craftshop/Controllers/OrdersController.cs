using Craftshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Craftshop.Controllers;

public class OrdersController : Controller

{
    private readonly CraftShopContext _context;
    public OrdersController(CraftShopContext context)
    {
        _context = context;
    }
    [HttpPost("orders/create")]
    public IActionResult CreateOrder(Order newOrder)
    {
        Craft? craft = _context.Crafts.Include(craft => craft.Owner).FirstOrDefault(craft => craft.CraftId == newOrder.CraftId);
        if (ModelState.IsValid)
        {
            if (craft.Quntity >= newOrder.Quantity)
            {
                _context.Add(newOrder);
                craft.Quntity -= newOrder.Quantity;
                _context.SaveChanges();
                return RedirectToAction("ShopCrafts", "Crafts");
            }
            ModelState.AddModelError("Quantity", "please Enter a Valid quantity");
            return View("~/Views/Crafts/ShowCraft.cshtml", craft);

        }
        return View("~/Views/Crafts/ShowCraft.cshtml", craft);
    }
    [HttpGet("ordehistory")]
    public IActionResult OrderHistory()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("LogReg", "Users");
        }
        int UserId = (int)HttpContext.Session.GetInt32("userId");
        // List<Craft> sales = _context.Crafts.
        // User? user = _context.Users
        // .Include(user => user.MyOrders)
        // .ThenInclude(order => order.Craft)
        // .ThenInclude(craft =>craft.Owner)
        // .FirstOrDefault(user =>user.UserId == UserId);
        List<Order> orders = _context.Orders
        .Include(order => order.Craft)
        .ThenInclude(craft=>craft.Owner)
        .Where(order=> order.UserId == UserId).ToList();
        List<Order> sales = _context.Orders
        .Include(order => order.Buyer)
        .Include(order=>order.Craft)
        .Where(order=> order.Craft.UserId == UserId).ToList();

        OrderHistoryView orderHistory = new OrderHistoryView(){
            Sales = sales,
            Orders =orders
        };
        return View(orderHistory);

    }
}