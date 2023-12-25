using AutoMapper;
using StockMarket.ApplicationService.DTOs;
using StockMarket.Domain.Entities;

namespace StockMarket.ApplicationService.MappingProfiles
{


    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Stock, StockDto>().ReverseMap();
            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.StockName, opt => opt.MapFrom(src => src.Stock.Name));
            CreateMap<OrderCreateOrUpdateDto, Order>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }

}
