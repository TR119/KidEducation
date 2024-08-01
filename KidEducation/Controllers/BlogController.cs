using Microsoft.AspNetCore.Mvc;

namespace KidEducation.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
