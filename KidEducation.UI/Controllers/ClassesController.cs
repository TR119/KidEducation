using Microsoft.AspNetCore.Mvc;

namespace KidEducation.UI.Controllers
{
    public class ClassesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
