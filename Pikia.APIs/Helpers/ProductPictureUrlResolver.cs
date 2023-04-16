using AutoMapper;
using AutoMapper.Execution;
using Microsoft.Extensions.Configuration;
using Pikia.APIs.DTOs;
using Pikia.Core.Entities;

namespace Pikia.APIs.Helpers
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        public IConfiguration Configuration { get; }

        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureURL))
                return $"{Configuration["BaseApiUrl"]}{source.PictureURL}";
            return null;
        }
    }
}
