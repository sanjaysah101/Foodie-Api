using System.ComponentModel.DataAnnotations;

namespace Foodie_Api.Dtos.Booking
{
    public class GetBookingDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime? Date { get; set; }
        public int NoOfPeople { get; set; }
        public string? Message { get; set; }
    }
}
