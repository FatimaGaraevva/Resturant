using Microsoft.AspNetCore.Mvc;

namespace Resturants.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
