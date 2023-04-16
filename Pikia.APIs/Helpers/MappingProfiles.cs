using AutoMapper;
using Pikia.APIs.DTOs;
using Pikia.Core.Entities;
using Pikia.Core.Entities.Order_Aggregate;

namespace Pikia.APIs.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductType, O => O.MapFrom(S => S.ProductType.Name))
                .ForMember(d => d.PictureURL, O => O.MapFrom<ProductPictureUrlResolver>());

           

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, O => O.MapFrom(S => S.Product.ProductId))
                .ForMember(d => d.ProductName, O => O.MapFrom(S => S.Product.ProductName))
                .ForMember(d => d.PictureUrl, O => O.MapFrom(S => S.Product.PictureUrl))
                .ForMember(d => d.PictureUrl, O => O.MapFrom<OrderItemPictureUrlResolver>());

            CreateMap<AddressDto, Core.Entities.Order_Aggregate.Address>();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<Order, OrderToReturnDto>();

        }
    }
}
