using Microsoft.EntityFrameworkCore;
using Pikia.Core.Entities;
using Pikia.Core.Repositories;
using Pikia.Core.Specification;
using Pikia.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikia.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly PikiaStore context;

        public GenericRepository(PikiaStore _context)
        {
            context = _context;
        }
       

        public async Task<IReadOnlyList<T>> GetAllTypesAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        => await context.Set<T>().FindAsync(id);





        public async Task<IEnumerable<T>> GetProductsSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        public async Task<T> GetByIdWitSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(context.Set<T>(), spec);
        }
         




        public async Task CreateAsync(T entity)
        => await context.Set<T>().AddAsync( entity);
        

        public  void Update(T entity)
        =>   context.Set<T>().Update(entity);
        

        public void Delete(T entity)
        => context.Set<T>().Remove(entity);

       
    }
}
