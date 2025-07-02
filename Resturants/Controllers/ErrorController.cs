using Microsoft.AspNetCore.Mvc;

namespace Resturants.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
