using Pikia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikia.Core.Specification
{
    public class ProductWithAndTypeSpecification : Specification<Product>
    {
        public ProductWithAndTypeSpecification()
        {
            Includes.Add(P => P.ProductType);
        }

        public ProductWithAndTypeSpecification(int id ): base( P => P.ProductTypeId == id)
        {
            Includes.Add(P => P.ProductType);

        }
    }
}
