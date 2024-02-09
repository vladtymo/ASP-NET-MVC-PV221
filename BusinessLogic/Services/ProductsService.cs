using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IMapper mapper;
        private readonly ShopDbContext context;

        public ProductsService(IMapper mapper, ShopDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public void Create(CreateProductModel product)
        {
            context.Products.Add(mapper.Map<Product>(product));
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            // delete product by id
            var product = context.Products.Find(id);

            if (product == null) return; // TODO: throw exception

            context.Remove(product);
            context.SaveChanges();
        }

        public void Edit(ProductDto product)
        {
            context.Products.Update(mapper.Map<Product>(product));
            context.SaveChanges();
        }

        public ProductDto? Get(int id)
        {
            var item = context.Products.Find(id);
            if (item == null) return null;

            // load related entity
            context.Entry(item).Reference(x => x.Category).Load();

            // convert entity type to DTO
            // 1 - using manually (handmade)
            //var dto = new ProductDto()
            //{
            //    Id = product.Id,
            //    CategoryId = product.CategoryId,
            //    Description = product.Description,
            //    Discount = product.Discount,
            //    ImageUrl = product.ImageUrl,
            //    InStock = product.InStock,
            //    Name = product.Name,
            //    Price = product.Price,
            //    CategoryName = product.Category.Name
            //};
            // 2 - using AutoMapper
            var dto = mapper.Map<ProductDto>(item);

            return dto;
        }

        public IEnumerable<ProductDto> Get(IEnumerable<int> ids)
        {
            return mapper.Map<List<ProductDto>>(context.Products
                .Include(x => x.Category)
                .Where(x => ids.Contains(x.Id))
                .ToList());
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return mapper.Map<List<ProductDto>>(context.Products.Include(x => x.Category).ToList());
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return mapper.Map<List<CategoryDto>>(context.Categories.ToList());
        }
    }
}
