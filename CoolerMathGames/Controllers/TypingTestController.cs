using CoolerMathGames.Data;
using CoolerMathGames.Interfaces;
using CoolerMathGames.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoolerMathGames.Controllers
{
    public class TypingTestController : Controller
    {
        ITypingTestDAL dal = new TypingTestDAL();

        public IActionResult TypingTest()
        {
            return View(dal.RandomizeSentences);
        }
    }
}
