using System.ComponentModel.DataAnnotations;

namespace Foodie_Api.Dtos.Booking
{
    public class AddBookingDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        public DateTime? Date { get; set; }
        public int NoOfPeople { get; set; }
        public string? Message { get; set; }
    }
}
