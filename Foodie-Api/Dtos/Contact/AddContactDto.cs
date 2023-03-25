using System.ComponentModel.DataAnnotations;

namespace Foodie_Api.Dtos.Contact
{
    public class AddContactDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
    }
}
