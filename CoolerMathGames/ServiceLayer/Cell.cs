using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CoolerMathGames.ServiceLayer
{
    public class Cell
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int BlockNumber { get; set; }
        [Range(1, Constants.BoardSize, ErrorMessage = Constants.CellErrorMessage)]
        public int? Value { get; set; }

        public Cell() { Value = null; }
    }
}
