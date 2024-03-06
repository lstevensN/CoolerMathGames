using CoolerMathGames.Models;
using CoolerMathGames.Interfaces;

namespace CoolerMathGames.Data
{
	public class GameCollectionDAL : IDataAccessLayer
	{
		private ApplicationDbContext db;

		public GameCollectionDAL(ApplicationDbContext indb)
		{
			db = indb;
		}

		public Game? GetGame(int? id)
		{
			Game? foundGame = db.Games.Where(m => m.Id == id).FirstOrDefault();
			return foundGame;
		}

		public IEnumerable<Game> GetCollection()
		{
			return db.Games;
		}

		public IEnumerable<Game> SearchForGames(string key)
		{
			if (key != null)
			{
				return GetCollection().Where(x => x.Name.ToLower().Contains(key.ToLower()));
			}
			return db.Games;
		}

		public IEnumerable<Game> FilterCollection()
		{
			throw new NotImplementedException();
		}
	}
}
