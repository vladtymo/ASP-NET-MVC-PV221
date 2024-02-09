using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces
{
    public interface IProductsService
    {
        IEnumerable<ProductDto> GetAll();
        IEnumerable<ProductDto> Get(IEnumerable<int> ids);
        ProductDto? Get(int id);
        IEnumerable<CategoryDto> GetAllCategories();
        void Create(CreateProductModel product);
        void Edit(ProductDto product);
        void Delete(int id);
    }
}
