using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces
{
    public interface IProductsService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto? Get(int id);
        IEnumerable<CategoryDto> GetAllCategories();
        void Create(ProductDto product);
        void Edit(ProductDto product);
        void Delete(int id);
    }
}
