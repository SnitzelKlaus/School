using Microsoft.AspNetCore.Mvc;

namespace MLStockAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
