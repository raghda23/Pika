using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pikia.APIs.DTOs;
using Pikia.APIs.Errors;
using Pikia.Core.Entities.Order_Aggregate;
using Pikia.Core.Services;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pikia.APIs.Controllers
{
    [Authorize]

    public class OrdersController : BaseApiController
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrdersController(IOrderService _orderService ,
            IMapper _mapper)
        {
            orderService = _orderService;
            mapper = _mapper;
        }
        [HttpPost]
        public async Task<ActionResult<OrderToReturnDto>> CreateOrder(OrderDto orderDto)
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var orderAddress = mapper.Map<AddressDto, Address>(orderDto.ShippingAddress);
            var order = await orderService.CreateOrderAsync(buyerEmail, orderDto.BasketId, orderAddress);
            if (order == null) return BadRequest(new ApiExceptionResponse(400));
            return Ok(mapper.Map<Order, OrderToReturnDto>(order));
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderToReturnDto>>> GetOrdersForUser()
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var orders = await orderService.GetOrdersForUserAsync(buyerEmail);
            return Ok(mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToReturnDto>>(orders));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrderForUser(int id)
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var order = await orderService.GetOrderByIdForUserAsync(id ,buyerEmail);
            if(order == null ) return BadRequest(new APIsResponse(400));
            return Ok(mapper.Map<Order, OrderToReturnDto>(order));
        }
    }
} 
 