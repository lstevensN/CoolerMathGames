using Microsoft.AspNetCore.Mvc;

namespace CoolerMathGames.Controllers
{
    public class CookieClickerController : Controller
    {
        [HttpGet]
        public IActionResult CookieClicker()
        {
            // 

            return View();
        }
    }
}
