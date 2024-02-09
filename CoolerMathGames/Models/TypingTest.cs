using System.Net;
using System.Reflection.Metadata;

namespace CoolerMathGames.Models
{
    public class TypingTest
    {
        public float Timer;
        public float MaxTime = 60;
        public float TimeLeft;
        public int? Mistakes = 0;
        public bool IsTyping = false;
        public float WPM;
        public float Accuracy;

        public TypingTest()
        {
            Timer = MaxTime;
            TimeLeft = Timer;
        }

        public TypingTest(float timer, float maxTime, float timeLeft, int? mistakes, bool isTyping, float wpm, float accuracy)
        {
            this.Timer = timer;
            this.MaxTime = maxTime;
            this.TimeLeft = timeLeft;
            this.Mistakes = mistakes;
            this.IsTyping = isTyping;
            this.WPM = wpm;
            this.Accuracy = accuracy;
        }

        public string Sentence;

        public TypingTest(string sentence)
        {
            this.Sentence = sentence;
        }
    }
}
