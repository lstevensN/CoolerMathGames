using CoolerMathGames.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoolerMathGames.Controllers
{
    public class EerieEnduranceController : Controller
    {
        private readonly ILogger<EerieEnduranceController> _logger;

        public EerieEnduranceController(ILogger<EerieEnduranceController> logger)
        {
            _logger = logger;
        }

        public IActionResult EerieEndurance()
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
