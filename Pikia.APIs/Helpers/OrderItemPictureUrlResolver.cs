using AutoMapper;
using Microsoft.Extensions.Configuration;
using Pikia.APIs.DTOs;
using Pikia.Core.Entities.Order_Aggregate;

namespace Pikia.APIs.Helpers
{
    public class OrderItemPictureUrlResolver : IValueResolver<OrderItem , OrderItemDto , string>
    {
        public IConfiguration Configuration { get; }

        public OrderItemPictureUrlResolver(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Product.PictureUrl))
                return $"{Configuration["BaseApiUrl"]}{source.Product.PictureUrl}";
            return null;
        }
    }
}
