using CoolerMathGames.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoolerMathGames.Controllers
{
    public class GalaxyGunshipController : Controller
    {
        private readonly ILogger<GalaxyGunshipController> _logger;

        public GalaxyGunshipController(ILogger<GalaxyGunshipController> logger)
        {
            _logger = logger;
        }

        public IActionResult GalaxyGunship()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
