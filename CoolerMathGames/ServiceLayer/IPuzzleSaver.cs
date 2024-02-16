namespace CoolerMathGames.ServiceLayer
{
    public interface IPuzzleSaver
    {
        void SavePuzzle(List<Cell> cellList, int puzzleNumber);

        void SavePuzzleSetup(List<Cell> cellList, ref int puzzleNumber);
    }
}
