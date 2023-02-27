using AutoMapper;
using AutoMapper.QueryableExtensions;
using Business.Abstarct;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.LogAspect;
using Core.Aspects.Autofac.Performance;
using Core.CrossCuttingConcerns.Logging.Log4Net.Layout.Loggers;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Quaries.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    [SecuredOperation("Product.List,Admin")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpPost("add")]
        public IActionResult Add([FromBody] Product product)
        {
            var result = _productService.Add(product);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        
        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] Product product)
        {
            var result = _productService.Delete(product);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("update")]
        public IActionResult Update([FromBody] Product product)
        {
            var result = _productService.Update(product);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getproductdetails")]
        public IActionResult GetProductDetails()
        {
            var result = _productService.GetProductDetails();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycategoryId")]
        public IActionResult GetAllByCategoryId([FromQuery] int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //[HttpGet("GetAllMappingTest")]
        //public IActionResult GetAllMapping(int id)
        //{
        //    var products = _productService.GetById(id).ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToList();


        //    return Ok(products);
        //}

    }
}
