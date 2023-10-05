using Microsoft.AspNetCore.Mvc;

namespace PortfolioOne

{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public string Index()
        {
            return "This is my index!";
        }
        [Route("projects")]
        [HttpGet]
        public string Projects()
        {
            return "These are my projects";
        }
        [Route("contact")]
        [HttpGet]
        public string Contact()
        {
            return "This is my contact";
        }
    }
}