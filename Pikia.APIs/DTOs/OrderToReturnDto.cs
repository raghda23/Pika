using Pikia.Core.Entities.Order_Aggregate;
using System;
using System.Collections.Generic;

namespace Pikia.APIs.DTOs
{
    public class OrderToReturnDto
    {
        public int Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string Status { get; set; } 
        public Address ShippingAddress { get; set; }
        public decimal Total { get; set; }

        public ICollection<OrderItemDto> Items { get; set; }
    }
}
