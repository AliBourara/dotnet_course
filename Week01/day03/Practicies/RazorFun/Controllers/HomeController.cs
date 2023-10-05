using Microsoft.AspNetCore.Mvc;
namespace YourNamespace.Controllers;
public class HomeController : Controller
{

    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View();
    }
}