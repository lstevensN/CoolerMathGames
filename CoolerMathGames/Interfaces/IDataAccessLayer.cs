using CoolerMathGames.Models;

namespace CoolerMathGames.Interfaces
{
	public interface IDataAccessLayer
	{
		Game? GetGame(int? id);
		IEnumerable<Game> GetCollection();
		IEnumerable<Game> SearchForGames(string key);
		IEnumerable<Game> FilterCollection();
	}
}
