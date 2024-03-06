using System.ComponentModel.DataAnnotations;

namespace CoolerMathGames.Models
{
	public class Game
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string? Name { get; set; }
		[Required]
		public string? Description { get; set; }
		[Required]
		public string? Image { get; set; }
		[Required]
		public string? GameLink { get; set; }

		public Game() { }

		public Game(string name, string description, string image, string? gameLink)
		{
			Name = name;
			Description = description;
			Image = image;
			GameLink = gameLink;
		}
	}
}
