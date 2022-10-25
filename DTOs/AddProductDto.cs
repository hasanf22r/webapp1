

namespace webapp1.DTOs
{
    public class AddProductDto
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public int CategoryId { get; set; }
    }
}