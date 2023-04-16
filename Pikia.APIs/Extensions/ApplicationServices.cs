using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Pikia.APIs.Errors;
using Pikia.APIs.Helpers;
using Pikia.Core.IRepositories;
using Pikia.Core.Repositories;
using Pikia.Core.Services;
using Pikia.Repository;
using Pikia.Service;
using System.Linq;

namespace Pikia.APIs.Extensions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IOrderService), typeof(OrderService));
            services.AddScoped(typeof(ITokenService), typeof(TokenService));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IBasketRepository), typeof(BasketRepository));
            services.AddAutoMapper(typeof(MappingProfiles));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(M => M.Value.Errors.Count() > 0)
                                                         .SelectMany(M => M.Value.Errors)
                                                         .Select(E => E.ErrorMessage);
                    var validationErrorResponse = new ApiValidationResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(validationErrorResponse);
                };

            });

            return services;
        }
    }
}
