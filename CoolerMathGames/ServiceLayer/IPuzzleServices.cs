using System;
using System.Collections.Generic;

namespace CoolerMathGames.ServiceLayer
{
    public interface IPuzzleServices
    {
        List<Cell> SetupBoard();

        PuzzleStatus GetPuzzleStatus(List<Cell> cellList);
    }
}
