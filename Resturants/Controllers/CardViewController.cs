using Microsoft.AspNetCore.Mvc;

namespace Resturants.Controllers
{
    public class CardViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
