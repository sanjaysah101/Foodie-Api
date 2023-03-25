using Foodie_Api.Dtos.Categories;

namespace Foodie_Api.Dtos.Items
{
    public class GetItemDto
    {
        public int Id { get; set; }        
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Images { get; set; } = string.Empty;
        public int Price { get; set; }
        //public GetCategoryDto? Category { get; set; }
        //public GetCategoryDto CategoryId { get; set; }
    }
}
