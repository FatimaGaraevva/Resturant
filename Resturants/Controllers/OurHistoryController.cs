using Microsoft.AspNetCore.Mvc;

namespace Resturants.Controllers
{
    public class OurHistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
