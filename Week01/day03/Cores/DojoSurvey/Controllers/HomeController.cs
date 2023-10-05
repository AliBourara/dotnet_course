using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers;

    public class HomeController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }


    [HttpPost("result")]
    public IActionResult Result(string name, string location, string langue, string comment)
        {   
            ViewBag.Name = name;
            ViewBag.Location = location;
            ViewBag.Language = langue;
            ViewBag.Comment = comment;
            return View();
        }
}