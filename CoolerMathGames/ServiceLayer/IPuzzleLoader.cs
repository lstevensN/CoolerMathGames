namespace CoolerMathGames.ServiceLayer
{
    public interface IPuzzleLoader
    {
        void LoadNewPuzzle(List<Cell> cellList, out int puzzleNumber);

        void ReloadPuzzle(List<Cell> cellList, int puzzleNumber);

        void LoadSavedPuzzle(List<Cell> cellList, out int puzzleNumber);
    }
}
