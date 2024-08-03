using Microsoft.AspNetCore.Mvc;

namespace KidEducation.UI.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
