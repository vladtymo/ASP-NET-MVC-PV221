using Microsoft.EntityFrameworkCore;
using MVC_pv221.Data.Entities;

namespace MVC_pv221.Data
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ShopDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new[]
            {
                new Product() { Id = 1, Name = "iPhone X", Category = "Electronics", Discount = 10, Price = 650, ImageUrl = "https://applecity.com.ua/image/cache/catalog/0iphone/ipohnex/iphone-x-black-1000x1000.png" },
                new Product() { Id = 2, Name = "PowerBall", Category = "Sport", Price = 45.5M, ImageUrl = "https://http2.mlstatic.com/D_NQ_NP_727192-CBT53879999753_022023-V.jpg" },
                new Product() { Id = 3, Name = "Nike T-Shirt", Category = "Fashion", Discount = 15, Price = 189, InStock = true, ImageUrl = "https://www.seekpng.com/png/detail/316-3168852_nike-air-logo-t-shirt-nike-t-shirt.png" },
                new Product() { Id = 4, Name = "Samsung S23", Category = "Electronics", Discount = 5, Price = 1200, InStock = true, ImageUrl = "https://sota.kh.ua/image/cache/data/Samsung-2/samsung-s23-s23plus-blk-01-700x700.webp" },
                new Product() { Id = 5, Name = "Air Ball", Category = "Toys & Hobbies", Price = 50, ImageUrl = "https://cdn.shopify.com/s/files/1/0046/1163/7320/products/69ee701e-e806-4c4d-b804-d53dc1f0e11a_grande.jpg" },
                new Product() { Id = 6, Name = "MacBook Pro 2019", Category = "Electronics", Discount = 10, InStock = true, Price = 1200, ImageUrl = "https://newtime.ua/image/import/catalog/mac/macbook_pro/MacBook-Pro-16-2019/MacBook-Pro-16-Space-Gray-2019/MacBook-Pro-16-Space-Gray-00.webp" }
            });
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    var str = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShopMvcPV221;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        //    optionsBuilder.UseSqlServer(str);
        //}
    }
}
