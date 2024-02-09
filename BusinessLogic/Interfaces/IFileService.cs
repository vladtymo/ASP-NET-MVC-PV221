using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveProductImage(IFormFile file);
        Task DeleteProductImage(string path);
    }
}
