using Microsoft.AspNetCore.Mvc;

namespace Resturants.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
