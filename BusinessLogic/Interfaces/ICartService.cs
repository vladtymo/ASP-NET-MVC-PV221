using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces
{
    public interface ICartService
    {
        IEnumerable<ProductDto> GetProducts();
        void Add(int id);
        void Remove(int id);
        int GetCount();
    }
}
