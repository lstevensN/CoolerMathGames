using CoolerMathGames.Models;

namespace CoolerMathGames.Interfaces
{
    public interface ITypingTestDAL
    {
        IEnumerable<TypingTest> GetTypingTests();

        void RandomizeSentences(string sentence);
    }
}
