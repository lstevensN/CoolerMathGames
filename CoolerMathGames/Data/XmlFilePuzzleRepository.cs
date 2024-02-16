using System.Xml.Linq;

namespace CoolerMathGames.Data
{
    public class XmlFilePuzzleRepository : IPuzzleRepository
    {
        private const string puzzleSetupXmlString = "PuzzleSetup.xml";
        private const string savedGameXmlString = "SavedGame.xml";

        readonly private string puzzleSetupXmlPath = string.Empty;
        readonly private string savedGameXmlPath = string.Empty;

        public XmlFilePuzzleRepository()
        {
            puzzleSetupXmlPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase.ToString(), puzzleSetupXmlString);
            savedGameXmlPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase.ToString(), savedGameXmlString);
        }

        public XDocument LoadPuzzleSetupXDoc()
        {
            return XDocument.Load(puzzleSetupXmlPath);
        }

        public XDocument LoadSavedGameXDoc()
        {
            return XDocument.Load(savedGameXmlPath);
        }

        public void SavePuzzleSetupXDoc(XDocument xDoc)
        {
            xDoc.Save(puzzleSetupXmlPath);
        }

        public void SaveSavedGameXDoc(XDocument xDoc)
        {
            xDoc.Save(savedGameXmlPath);
        }
    }
}
