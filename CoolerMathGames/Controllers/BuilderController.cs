using Microsoft.AspNetCore.Mvc;
using CoolerMathGames.Data;
using CoolerMathGames.Models;
using CoolerMathGames.ServiceLayer;

namespace CoolerMathGames.Controllers
{
    public class BuilderController : Controller
    {
        private XmlFilePuzzleRepository puzzleRepository = new XmlFilePuzzleRepository();
        private IPuzzleSaver puzzleSaver;
        private IPuzzleServices puzzleServices = new PuzzleServices();

        public BuilderController()
        {
            puzzleSaver = new XDocPuzzleSaver(puzzleRepository);

            // Load Constants into ViewData for partial views
            ViewData["BoardSize"] = Constants.BoardSize;
            ViewData["BlockSize"] = Constants.BlockSize;
        }

        public IActionResult CreatePuzzleSetup()
        {
            FullBoard board = new FullBoard() { BoardList = puzzleServices.SetupBoard() };

            return View("BuilderView", board);
        }

        public IActionResult UpdatePuzzleSetup(FullBoard board)
        {
            board.Status = puzzleServices.GetPuzzleStatus(board.BoardList);

            return View("BuilderView", board);
        }

        [HttpPost]
        public IActionResult SavePuzzleSetup(FullBoard board)
        {
            int puzzleNumber = board.BoardNumber;
            puzzleSaver.SavePuzzleSetup(board.BoardList, ref puzzleNumber);
            board.BoardNumber = puzzleNumber;
            board.Status = puzzleServices.GetPuzzleStatus(board.BoardList);

            // Returns the model's updated BoardNumber by redirecting to an HttpGet method
            TempData["Board"] = board;
            return RedirectToAction("SavePuzzleSetup");
        }

        [HttpGet]
        public IActionResult SavePuzzleSetup()
        {
            return View("BuilderView", (FullBoard)TempData["Board"]);
        }
    }
}
