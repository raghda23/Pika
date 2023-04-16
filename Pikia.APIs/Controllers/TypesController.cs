using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pikia.Core.Entities;
using Pikia.Core.Repositories;
using Pikia.Core.Specification;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pikia.APIs.Controllers
{
   
    public class TypesController : BaseApiController
    {
        private readonly IGenericRepository<ProductType> typeRepo;

        public TypesController(IGenericRepository<ProductType> _TypeRepo)
        {
            typeRepo = _TypeRepo;
        }
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetAllTypes()
        {
            var types = await typeRepo.GetAllTypesAsync();
            return Ok(types);
        }
    }
}
