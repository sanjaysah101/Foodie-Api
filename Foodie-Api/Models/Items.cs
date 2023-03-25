using System.ComponentModel.DataAnnotations;

namespace Foodie_Api.Models
{
    public class Items
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public string Images { get; set; } = string.Empty;
        public int Price { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
