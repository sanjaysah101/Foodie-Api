using Foodie_Api.Dtos.Items;

namespace Foodie_Api.Dtos.Categories
{
    public class GetCategoryDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Images { get; set; }
        public string? Tags { get; set; }
        //public GetUserDto User { get; set; }
        public int UserId { get; set; }
        public List<GetItemDto> Items { get; set; }
    }
}
