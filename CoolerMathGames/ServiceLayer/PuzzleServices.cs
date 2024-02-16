using Microsoft.VisualBasic;
using CoolerMathGames.ServiceLayer;

namespace CoolerMathGames.ServiceLayer
{
    public enum PuzzleStatus
    {
        Normal,
        Invalid,
        Complete
    }

    public class PuzzleServices : IPuzzleServices
    {
        public List<Cell> SetupBoard()
        {
            List<Cell> board = new List<Cell>();

            for (int x = 0; x < Constants.BoardSize; x++)
            {
                for (int y = 0; y < Constants.BoardSize; y++)
                {
                    Cell newCell = new Cell()
                    {
                        XCoordinate = x + 1,
                        YCoordinate = y + 1,
                        BlockNumber = Constants.BlockSize * (x / Constants.BlockSize) + y / Constants.BlockSize + 1
                    };
                    board.Add(newCell);
                }
            }

            return board;
        }

        public PuzzleStatus GetPuzzleStatus(List<Cell> cellList)
        {
            PuzzleStatus status;

            if (!IsPuzzleValid(cellList))
            {
                status = PuzzleStatus.Invalid;
            }
            else if (IsPuzzleComplete(cellList))
            {
                status = PuzzleStatus.Complete;
            }
            else
            {
                status = PuzzleStatus.Normal;
            }

            return status;
        }

        public static bool IsPuzzleValid(List<Cell> cellList)
        {
            bool isValid = AreRowsValid(cellList);
            isValid &= AreColumnsValid(cellList);
            isValid &= AreBlocksValid(cellList);

            return isValid;
        }

        private static bool AreRowsValid(List<Cell> cellList)
        {
            bool isValid = true;
            cellList.GroupBy(c => c.XCoordinate).Select(g => g.ToList()).ToList().ForEach(s => isValid &= IsValueUniqueInSet(s));
            return isValid;
        }

        private static bool AreColumnsValid(List<Cell> cellList)
        {
            bool isValid = true;
            cellList.GroupBy(c => c.YCoordinate).Select(g => g.ToList()).ToList().ForEach(s => isValid &= IsValueUniqueInSet(s));
            return isValid;
        }

        private static bool AreBlocksValid(List<Cell> cellList)
        {
            bool isValid = true;
            cellList.GroupBy(c => c.BlockNumber).Select(g => g.ToList()).ToList().ForEach(s => isValid &= IsValueUniqueInSet(s));
            return isValid;
        }

        private static bool IsValueUniqueInSet(List<Cell> cellGroup)
        {
            // Validate that each non-NULL value in this group is unique.  Ignore NULL values.
            return cellGroup.Where(c => c.Value.HasValue).GroupBy(c => c.Value.Value).All(g => g.Count() <= 1);
        }

        // Must be called after IsBoardValid().  A board can be completely filled in, but invalid.
        private static bool IsPuzzleComplete(List<Cell> cellList)
        {
            return cellList.All(c => c.Value.HasValue);
        }
    }
}
