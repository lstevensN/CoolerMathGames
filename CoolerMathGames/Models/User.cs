using System.ComponentModel.DataAnnotations;

namespace CoolerMathGames.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string? DisplayName { get; set; }
    }
}
