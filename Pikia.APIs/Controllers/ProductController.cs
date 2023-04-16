using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pikia.APIs.DTOs;
using Pikia.Core.Entities;
using Pikia.Core.Repositories;
using Pikia.Core.Specification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pikia.APIs.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IMapper mapper;

        public ProductController(IGenericRepository<Product> _productRepo , IMapper _mapper)
        {
            productRepo = _productRepo;
            mapper = _mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetAllProducts()
        {
            var spec = new ProductWithAndTypeSpecification();
            var products = await productRepo.GetAllWithSpecAsync(spec);
            return Ok(mapper.Map<IEnumerable<Product> , IEnumerable<ProductToReturnDto>>(products));
        }




        [HttpGet("Plastek")]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetPlastekProductsAsync()
        {
            var spec = new ProductWithAndTypeSpecification(1);
            var products = await productRepo.GetProductsSpecAsync(spec);
            return Ok(mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(products));
        }



        [HttpGet("Mentals")]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetMentalsProductsAsync()
        {
            var spec = new ProductWithAndTypeSpecification(2);
            var products = await productRepo.GetProductsSpecAsync(spec);
            return Ok(mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(products));
        }

        [HttpGet("Old Devices")]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetOldDevicesProductsAsync()
        {
            var spec = new ProductWithAndTypeSpecification(3);
            var products = await productRepo.GetProductsSpecAsync(spec);
            return Ok(mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(products));
        }

        [HttpGet("Housewares")]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetHousewaresProductsAsync()
        {
            var spec = new ProductWithAndTypeSpecification(4);
            var products = await productRepo.GetProductsSpecAsync(spec);
            return Ok(mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(products));
        }


        [HttpGet("Antekat")]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetAntekatProductsAsync()
        {
            var spec = new ProductWithAndTypeSpecification(5);
            var products = await productRepo.GetProductsSpecAsync(spec);
            return Ok(mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(products));
        }


        [HttpGet("Khorda")]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetKhordaProductsAsync()
        {
            var spec = new ProductWithAndTypeSpecification(6);
            var products = await productRepo.GetProductsSpecAsync(spec);
            return Ok(mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(products));
        }



        [HttpGet("Sports Goods")]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetSportsgoodsProductsAsync()
        {
            var spec = new ProductWithAndTypeSpecification(7);
            var products = await productRepo.GetProductsSpecAsync(spec);
            return Ok(mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(products));
        }

        [HttpGet("Cartoon Paper")]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetCartoonPaperProductsAsync()
        {
            var spec = new ProductWithAndTypeSpecification(8);
            var products = await productRepo.GetProductsSpecAsync(spec);
            return Ok(mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(products));
        }


    }
}
