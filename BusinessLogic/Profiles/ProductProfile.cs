using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile(IFileService fileService)
        {
            CreateMap<ProductDto, Product>()
                .ForMember(x => x.Category, opt => opt.Ignore());
            CreateMap<Product, ProductDto>();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();

            CreateMap<CreateProductModel, Product>()
                .ForMember(x => x.ImageUrl, opt => opt.MapFrom(src => fileService.SaveProductImage(src.Image).Result));

            CreateMap<Order, OrderSummaryModel>()
                .ForMember(x => x.Number, opts => opts.MapFrom(src => src.Id))
                .ForMember(x => x.UserName, opts => opts.MapFrom(src => src.User.UserName));
        }
    }
}
