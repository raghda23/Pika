 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikia.Core.Entities
{
    public class Product : BaseEntity
    {
        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PictureURL { get; set; }
        public int ProductTypeId { get; set; } //productType foriegn key
        public  ProductType ProductType { get; set; } // navigational property
    }
}
