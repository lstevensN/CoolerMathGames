// Huge thanks to AmosLong for the walkthrough on how to make a MVC Sudoku Game!
// Full credits go to them: https://www.codeproject.com/Articles/1119451/MVC-Sudoku

using Microsoft.AspNetCore.Mvc;
using CoolerMathGames.Data;
using CoolerMathGames.Models;
using CoolerMathGames.ServiceLayer;

namespace CoolerMathGames.Controllers
{
    public class SudokuController : Controller
    {
        private XmlFilePuzzleRepository puzzleRepository = new XmlFilePuzzleRepository();

        private IPuzzleLoader puzzleLoader;
        private IPuzzleSaver puzzleSaver;
        private IPuzzleServices puzzleServices = new PuzzleServices();

        public SudokuController()
        {
            puzzleLoader = new XDocPuzzleLoader(puzzleRepository);
            puzzleSaver = new XDocPuzzleSaver(puzzleRepository);

            // Load Constants into ViewData for partial views
            ViewData["BoardSize"] = Constants.BoardSize;
            ViewData["BlockSize"] = Constants.BlockSize;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sudoku()
        {
            FullBoard board = new FullBoard() { BoardList = puzzleServices.SetupBoard() };

            int puzzleNumber;
            puzzleLoader.LoadNewPuzzle(board.BoardList, out puzzleNumber);
            board.BoardNumber = puzzleNumber;

            return View("GameView", board);
        }

        public IActionResult UpdateSudoku(FullBoard board)
        {
            board.Status = puzzleServices.GetPuzzleStatus(board.BoardList);

            return View("GameView", board);
        }

        public IActionResult ResetSudoku(FullBoard board)
        {
            board.BoardList = puzzleServices.SetupBoard();
            puzzleLoader.ReloadPuzzle(board.BoardList, board.BoardNumber);

            return View("GameView", board);
        }

        public IActionResult SaveSudoku(FullBoard board)
        {
            puzzleSaver.SavePuzzle(board.BoardList, board.BoardNumber);
            board.Status = puzzleServices.GetPuzzleStatus(board.BoardList);

            return View("GameView", board);
        }

        public IActionResult LoadSudoku()
        {
            FullBoard board = new FullBoard() { BoardList = puzzleServices.SetupBoard() };
            
            int puzzleNumber;
            puzzleLoader.LoadSavedPuzzle(board.BoardList, out puzzleNumber);
            board.Status = puzzleServices.GetPuzzleStatus(board.BoardList);
            board.BoardNumber = puzzleNumber;

            return View("GameView", board);
        }
    }
}
