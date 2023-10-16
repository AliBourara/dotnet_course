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
}