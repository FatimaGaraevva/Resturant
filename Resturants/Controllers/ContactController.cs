using Microsoft.AspNetCore.Mvc;

namespace Resturants.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
