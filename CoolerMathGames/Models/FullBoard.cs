using CoolerMathGames.ServiceLayer;

namespace CoolerMathGames.Models
{
    public class FullBoard
    {
        public List<Cell> BoardList { get; set; }
        public int BoardNumber { get; set; }
        public PuzzleStatus Status { get; set; }

        public FullBoard() 
        {
            BoardList = new List<Cell>();
            Status = PuzzleStatus.Normal;
        }
    }
}
