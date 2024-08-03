using Microsoft.AspNetCore.Mvc;

namespace KidEducation.UI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
