using Microsoft.AspNetCore.Mvc;

namespace KidEducation.Controllers
{
    public class ClassesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
