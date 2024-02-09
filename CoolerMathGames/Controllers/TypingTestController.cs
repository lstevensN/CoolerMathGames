using CoolerMathGames.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoolerMathGames.Controllers
{
    public class TypingTestController : Controller
    {
        private static List<TypingTest> SentenceList = new List<TypingTest>()
        {
            new TypingTest("After a few miles of walking, we began to hear a familiar screech in the distance."),
            new TypingTest("Grover explained that he'd come across Gladiola in the woods and they'd struck up a conversation."),
            new TypingTest("A strange breeze rustled through the clearing, temporarily overpowering the stink of trash and muck."),
            new TypingTest("Instead of finding a path, I immediately slammed into a tree and got a nice-size knot on my head."),
            new TypingTest("Our guy Maurice rolled his eyes and went back outside, cursing at Eddie for being an idiot.")
        };

        public IActionResult TypingTest()
        {
            TypingTest sentence = SentenceList[new Random().Next(0, SentenceList.Count)];

            return View(sentence);
        }
    }
}
