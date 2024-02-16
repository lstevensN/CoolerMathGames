using System.Xml.Linq;

namespace CoolerMathGames.Data
{
    public interface IPuzzleRepository
    {
        XDocument LoadPuzzleSetupXDoc();

        XDocument LoadSavedGameXDoc();

        void SavePuzzleSetupXDoc(XDocument xDoc);

        void SaveSavedGameXDoc(XDocument xDoc);
    }
}
