using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikia.Core.Entities.Order_Aggregate
{
    public class Order :BaseEntity
    {
        public Order()
        {

        }

        public Order(string buyerEmail, Address shippingAddress, decimal total, ICollection<OrderItem> items)
        {
            BuyerEmail = buyerEmail;
            ShippingAddress = shippingAddress;
            Total = total;
            Items = items;
        }

        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public Address ShippingAddress { get; set; }
        public decimal Total { get; set; }

        public ICollection<OrderItem> Items { get; set; }


       
    }
}
