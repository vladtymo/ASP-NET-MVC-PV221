using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using AutoMapper;
using BusinessLogic;
using DataAccess;
using BusinessLogic.Services;
using BusinessLogic.Interfaces;
using MVC_pv221.Services;

namespace MVC_pv221
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connStr = builder.Configuration.GetConnectionString("LocalDb")!;

            // Add services to the container.
            // DI - Dependency Injection
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext(connStr);

            builder.Services.AddAutoMapper();
            builder.Services.AddFluentValidators();

            builder.Services.AddCustomServices();
            builder.Services.AddScoped<ICartService, CartService>();

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
