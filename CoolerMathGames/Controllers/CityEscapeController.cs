using CoolerMathGames.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoolerMathGames.Controllers
{
    public class CityEscapeController : Controller
    {
        private readonly ILogger<CityEscapeController> _logger;

        public CityEscapeController(ILogger<CityEscapeController> logger)
        {
            _logger = logger;
        }

        public IActionResult CityEscape()
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
