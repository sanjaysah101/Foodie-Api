
namespace Foodie_Api.Dtos.Categories
{
    public class AddCategoryDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Images { get; set; }
        public string? Tags { get; set; }
        //public GetUserDto User { get; set; }
        public int UserId { get; set; }
    }
}
