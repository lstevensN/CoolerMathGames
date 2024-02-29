using System.Collections.Generic;
using CoolerMathGames.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using CoolerMathGames.Interfaces;

namespace CoolerMathGames.Controllers
{
    public class TypingTestController : Controller
    {
        /*
        ITypingTestDAL dal;
        public TypingTestController(ITypingTestDAL indal)
        {
            dal = indal;
        }
        */

        private static List<TypingTest> SentenceList = new List<TypingTest>()
        {
            new TypingTest("After a few miles of walking, we began to hear a familiar screech in the distance."),
            new TypingTest("Grover explained that he'd come across Gladiola in the woods and they'd struck up a conversation."),
            new TypingTest("A strange breeze rustled through the clearing, temporarily overpowering the stink of trash and muck."),
            new TypingTest("Instead of finding a path, I immediately slammed into a tree and got a nice-size knot on my head."),
            new TypingTest("Our guy Maurice rolled his eyes and went back outside, cursing at Eddie for being an idiot.")
        };

        [HttpGet]
        public IActionResult TypingTest()
        {
            TypingTest randomSentence = SentenceList[new Random().Next(0, SentenceList.Count)];

            return View(randomSentence);
        }

        public IActionResult TryAgain()
        {
            TypingTest randomSentence = SentenceList[new Random().Next(0, SentenceList.Count)];

            return View("TypingTest", randomSentence);
        }

        public IActionResult Results(int mistakes, float timeSpent, float WPM)
        {
            TypingTest model = new TypingTest();
            model.Mistakes = mistakes;
            model.TimeSpentTyping = timeSpent;
            model.WPM = WPM;

            if (WPM > model.highScoreWPM)
            {
                model.highScoreWPM = WPM;
            }

            return View("Results", model);
        }
    }
}
