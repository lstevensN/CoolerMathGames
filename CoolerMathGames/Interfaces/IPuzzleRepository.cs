using System.Xml.Linq;

namespace CoolerMathGames.Interfaces
{
    public interface IPuzzleRepository
    {
        XDocument LoadPuzzleSetupXDoc();

        XDocument LoadSavedGameXDoc();

        void SavePuzzleSetupXDoc(XDocument xDoc);

        void SaveSavedGameXDoc(XDocument xDoc);
    }
}
