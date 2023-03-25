using System.ComponentModel.DataAnnotations;

namespace Foodie_Api.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }

    }
}
