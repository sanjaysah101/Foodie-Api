using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Foodie_Api.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public int NoOfPeople { get; set; }
        public string? Message { get; set; }
    }
}
