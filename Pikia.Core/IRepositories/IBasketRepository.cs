using Pikia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikia.Core.IRepositories
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string basketId);
        Task<CustomerBasket> UpdateBaketAsync (CustomerBasket basket);
        Task<bool> DeleteBaketAsync(string basketId);
    }
}
