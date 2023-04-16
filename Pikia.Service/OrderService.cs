using Pikia.Core.Entities;
using Pikia.Core.Entities.Order_Aggregate;
using Pikia.Core.IRepositories;
using Pikia.Core.Repositories;
using Pikia.Core.Services;
using Pikia.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikia.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository basketRepo;
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<Product> productRepo;

        public OrderService(IBasketRepository _basketRepo,
           IUnitOfWork _unitOfWork ,
           IGenericRepository<Product> _productRepo)
        {
            basketRepo = _basketRepo;
            unitOfWork = _unitOfWork;
            productRepo = _productRepo;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, string basketId, Address shippingAddress)
        {
            var basket = await basketRepo.GetBasketAsync(basketId);
            var orderItems = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var product = await unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                var productItemOrdered = new ProductItemOrdered(product.Id , product.Name , product.PictureURL);
                var OrderItem = new OrderItem(productItemOrdered , product.Price , item.Quantity);

                orderItems.Add(OrderItem);
                
            }

            var total = orderItems.Sum(item => item.Quantity * item.Price);
            var order = new Order(buyerEmail, shippingAddress , total , orderItems);
            await unitOfWork.Repository<Order>().CreateAsync(order);
            var result = await unitOfWork.Complete();
            if(result < 0 ) return null;
            return order;
        }

       

        public async Task<Order> GetOrderByIdForUserAsync(int OrderId, string buyerEmail)
        {
            var spec = new OrderWithItemsSpecification(OrderId , buyerEmail);
            var order = await unitOfWork.Repository<Order>().GetByIdWitSpecAsync(spec);
            return order;
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            var spec = new OrderWithItemsSpecification(buyerEmail);
            var orders = await unitOfWork.Repository<Order>().GetAllWithSpecAsync(spec);
            return orders ;
        }
    }
}
