using Microsoft.AspNetCore.Mvc;

namespace KidEducation.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
