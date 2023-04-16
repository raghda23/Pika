using Pikia.Core.Entities.Order_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikia.Core.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(string buyerEmail , string basketId , Address shippingAddress);
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);
        Task<Order> GetOrderByIdForUserAsync(int OrderId , string buyerEmail);
    }
}
