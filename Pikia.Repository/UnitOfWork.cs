using Pikia.Core.Entities;
using Pikia.Core.IRepositories;
using Pikia.Core.Repositories;
using Pikia.Repository.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikia.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PikiaStore context;
        private Hashtable repositories;

        public UnitOfWork(PikiaStore _context)
        {
            context = _context;
        }
        public async Task<int> Complete()
        =>  await context.SaveChangesAsync();

        public void Dispose()
        {
            context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
           repositories ??= new Hashtable();

           var type = typeof(TEntity).Name;
            if(!repositories.ContainsKey(type))
            {
                var repository = new GenericRepository<TEntity>(context);
                repositories.Add(type, repository);
            }

            return (IGenericRepository<TEntity>) repositories[type];
        }


    }
}
