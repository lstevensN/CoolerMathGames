using System.ComponentModel.DataAnnotations;

namespace CoolerMathGames.Models
{
	public class Game
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string? Description { get; set; }
		[Required]
		public string? Image { get; set; }

		public Game() { }

		public Game(string description, string image)
		{
			this.Description = description;
			this.Image = image;
		}
	}
}
