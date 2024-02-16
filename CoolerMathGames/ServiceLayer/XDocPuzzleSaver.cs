using CoolerMathGames.Data;
using System.Xml.Linq;

namespace CoolerMathGames.ServiceLayer
{
    public class XDocPuzzleSaver : IPuzzleSaver
    {
        private IPuzzleRepository puzzleRepository = null;

        public XDocPuzzleSaver(IPuzzleRepository xDocPuzzleRepository)
        {
            puzzleRepository = xDocPuzzleRepository;
        }

        public void SavePuzzle(List<Cell> cellList, int puzzleNumber)
        {
            XDocument savedGameXDoc = InitializeSavedGameXDoc();

            SavePuzzleInXDoc(cellList, savedGameXDoc, puzzleNumber, puzzleRepository.SaveSavedGameXDoc);
        }

        public void SavePuzzleSetup(List<Cell> cellList, ref int puzzleNumber)
        {
            XDocument puzzleSetupXDoc = puzzleRepository.LoadPuzzleSetupXDoc();

            bool puzzleExists = (puzzleNumber > 0);
            if (puzzleExists)
            {
                OverwritePuzzleInXDoc(cellList, puzzleSetupXDoc, puzzleNumber);
            }
            else
            {
                puzzleNumber = FindNextAvailablePuzzleNumber(puzzleSetupXDoc);
                SavePuzzleInXDoc(cellList, puzzleSetupXDoc, puzzleNumber, puzzleRepository.SavePuzzleSetupXDoc);
            }
        }

        private XDocument InitializeSavedGameXDoc()
        {
            XDocument savedGameXDoc = new XDocument();
            savedGameXDoc.Declaration = new XDeclaration("1.0", "utf-8", "true");
            savedGameXDoc.Add(new XElement("PuzzleSetup"));

            return savedGameXDoc;
        }

        private void OverwritePuzzleInXDoc(List<Cell> cellList, XDocument puzzleSetupXDoc, int puzzleNumber)
        {
            XElement cellsXElement = puzzleSetupXDoc.Descendants("Puzzle").First(b => (int)b.Element("Number") == puzzleNumber).Element("Cells");
            cellsXElement.ReplaceWith(CreateCellsXElement(cellList));

            puzzleRepository.SavePuzzleSetupXDoc(puzzleSetupXDoc);
        }

        private int FindNextAvailablePuzzleNumber(XDocument existingPuzzleXDoc)
        {
            return existingPuzzleXDoc.Descendants("Puzzle").Max(b => (int)b.Element("Number")) + 1;
        }

        private static void SavePuzzleInXDoc(List<Cell> cellList, XDocument saveXDoc, int puzzleNumber, Action<XDocument> saveMethod)
        {
            saveXDoc.Element("PuzzleSetup").Add(
                new XElement("Puzzle",
                    new XElement("Number", puzzleNumber),
                    new XElement("Difficulty"),
                    CreateCellsXElement(cellList)));

            saveMethod(saveXDoc);
        }

        private static XElement CreateCellsXElement(List<Cell> cellList) 
        {
            return new XElement("Cells", cellList.Select((c, i) => c.Value.HasValue ? 
                new XElement("Cell", new XAttribute("index", i), new XAttribute("value", c.Value.Value)) : null));
        }
    }
}
