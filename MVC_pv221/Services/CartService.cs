using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVC_pv221.Helpers;
using System.Text.Json;

namespace MVC_pv221.Services
{
    public class CartService : ICartService
    {
        const string key = "cart_items_key";
        private readonly IProductsService productsService;
        private readonly HttpContext httpContext;

        public CartService(IProductsService productsService, IHttpContextAccessor contextAccessor)
        {
            this.productsService = productsService;
            httpContext = contextAccessor.HttpContext ?? throw new Exception();
        }

        private List<int> GetCartItems() => httpContext.Session.Get<List<int>>(key) ?? new();
        private void SaveCartItems(List<int> items) => httpContext.Session.SetString(key, JsonSerializer.Serialize(items));

        public void Add(int id)
        {
            var ids = GetCartItems();
            ids.Add(id);

            SaveCartItems(ids);
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            var ids = GetCartItems();
            return productsService.Get(ids);
        }

        public void Remove(int id)
        {
            var ids = GetCartItems();
            ids.Remove(id);

            SaveCartItems(ids);
        }

        public int GetCount()
        {
            return GetCartItems().Count;
        }
    }
}
