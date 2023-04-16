using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pikia.APIs.DTOs;
using Pikia.Core.Entities;
using Pikia.Core.IRepositories;
using System.Threading.Tasks;

namespace Pikia.APIs.Controllers
{
    
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository basketRepo;
        private readonly IMapper mapper;

        public BasketController(IBasketRepository _basketRepo , IMapper _mapper)
        {
            basketRepo = _basketRepo;
            mapper = _mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await basketRepo.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> updateBasket(CustomerBasketDto basket)
        {
            var mapped = mapper.Map<CustomerBasketDto, CustomerBasket>(basket);
            var updatedOrCraeted = await basketRepo.UpdateBaketAsync(mapped);
            return Ok(updatedOrCraeted );
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteBasket(string id)
        {
           await basketRepo.DeleteBaketAsync(id);
            return Ok("Delete Done");
           
        }
    }
}
