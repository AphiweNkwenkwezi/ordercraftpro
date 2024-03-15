using Microsoft.AspNetCore.Mvc;

namespace OrderCraftPro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
