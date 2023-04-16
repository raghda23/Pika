using Pikia.Core.Entities.Order_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikia.Core.Specification
{
    public class OrderWithItemsSpecification : Specification<Order>
    {
        public OrderWithItemsSpecification(string buyerEmail) : base(O => O.BuyerEmail == buyerEmail)
        {
            Includes.Add(O => O.Items);

            AddOrderByDesc(O => O.OrderDate);
        }

        public OrderWithItemsSpecification(int orderId ,string buyerEmail) : base(O => O.BuyerEmail == buyerEmail && O.Id == orderId)
        {
            Includes.Add(O => O.Items);
        }
    }
}
