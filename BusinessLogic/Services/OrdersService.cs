using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    internal class OrdersService : IOrdersService
    {
        private readonly IMapper mapper;
        private readonly ShopDbContext context;
        private readonly ICartService cartService;
        private readonly IEmailSender emailSender;
        private readonly IViewRender viewRender;

        public OrdersService(IMapper mapper, 
                            ShopDbContext context, 
                            ICartService cartService,
                            IEmailSender emailSender,
                            IViewRender viewRender)
        {
            this.mapper = mapper;
            this.context = context;
            this.cartService = cartService;
            this.emailSender = emailSender;
            this.viewRender = viewRender;
        }

        public async Task Create(string userId)
        {
            var ids = cartService.GetProductIds();
            var products = context.Products.Where(x => ids.Contains(x.Id)).ToList();

            var order = new Order()
            {
                Date = DateTime.Now,
                UserId = userId,
                Products = products,
                TotalPrice = products.Sum(x => x.Price),
            };

            context.Orders.Add(order);
            context.SaveChanges();

            context.Entry(order).Reference(x => x.User).Load();

            // send order summary email
            var orderSummary = mapper.Map<OrderSummaryModel>(order);
            string html = viewRender.Render("MailTemplates/OrderSummary", orderSummary);

            await emailSender.SendEmailAsync("tymo.vlad@gmail.com", $"Order #{orderSummary.Number}", html);
        }

        public IEnumerable<OrderDto> GetAllByUser(string userId)
        {
            var items = context.Orders.Include(x => x.Products).Where(x => x.UserId == userId).ToList();
            return mapper.Map<IEnumerable<OrderDto>>(items);
        }
    }
}
