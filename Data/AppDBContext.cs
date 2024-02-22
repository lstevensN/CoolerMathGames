using Microsoft.EntityFrameworkCore;
using CoolerMathGames.Models;

namespace CoolerMathGames.Data
{
	public class AppDBContext : DbContext
	{
		public AppDBContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Game> Games { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
