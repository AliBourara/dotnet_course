using Microsoft.AspNetCore.Mvc;

namespace TimeDisplay.Controllers;

    public class HomeController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        ViewBag.CurrentTime = DateTime.Now;
        return View();
    }

}