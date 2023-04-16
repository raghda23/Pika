using Pikia.Core.Entities;
using Pikia.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikia.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllTypesAsync();
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetProductsSpecAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec);
        Task<T> GetByIdWitSpecAsync(ISpecification<T> spec);

        Task CreateAsync( T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
