using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces
{
    public interface IOrdersService
    {
        IEnumerable<OrderDto> GetAllByUser(string userId);
        Task Create(string userId);
    }
}
