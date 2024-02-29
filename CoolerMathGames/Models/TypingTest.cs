using System.Net;
using System.Reflection.Metadata;

namespace CoolerMathGames.Models
{
    public class TypingTest
    {
        public float Timer = 0;
        public float MaxTime = 60;
        public float TimeLeft = 0;

        public float TimeSpentTyping = 0;

        public int? Mistakes = 0;
        public float? WPM = 0;

        public float? highScoreWPM = 0;

        public TypingTest() { }

        public TypingTest(float timer, float maxTime, float timeLeft, int? mistakes, float wpm)
        {
            this.Timer = timer;
            this.MaxTime = maxTime;
            this.TimeLeft = timeLeft;
            this.Mistakes = mistakes;
            this.WPM = wpm;
        }

        public string Sentence;

        public TypingTest(string sentence)
        {
            this.Sentence = sentence;
        }
    }
}
