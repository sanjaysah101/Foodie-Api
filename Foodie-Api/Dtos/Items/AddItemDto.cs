using System.ComponentModel.DataAnnotations;

namespace Foodie_Api.Dtos.Items
{
    public class AddItemDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public string Images { get; set; } = string.Empty;
        public int Price { get; set; }
        public int CategoryId { get; set; }
    }
}
