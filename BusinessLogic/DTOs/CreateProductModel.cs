using Microsoft.AspNetCore.Http;

namespace BusinessLogic.DTOs
{
    public class CreateProductModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public bool InStock { get; set; }
        public IFormFile Image { get; set; }
    }
}
