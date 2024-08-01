using Microsoft.AspNetCore.Mvc;

namespace KidEducation.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
