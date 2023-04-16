using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pikia.Core.Entities.Order_Aggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "OrderRecieved")]
        OrderRecieved,
        [EnumMember(Value = "OrderFailed")]
        OrderFailed
    }
}
