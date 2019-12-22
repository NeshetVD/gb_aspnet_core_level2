using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities;
using WebStore.Domain.Filters;
using WebStore.DomainNew.Dto;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.ServicesHosting.Controllers
{
    [Route("api/products")]
    [Produces("application/json")]
    [ApiController]
    public class ProductsApiController : ControllerBase, IProductService
    {
        private readonly IProductService _productData;

        public ProductsApiController(IProductService productData)
        {
            _productData = productData ?? throw new ArgumentException(nameof(productData));
        }

        [HttpGet("brands")]
        public IEnumerable<Brand> GetBrands()
        {
            return _productData.GetBrands();
        }

        public ProductDto GetProductById(int id)
        {
            return _productData.GetProductById(id);
        }

        [HttpPost]
        [ActionName("Post")]
        public IEnumerable<ProductDto> GetProducts([FromBody]ProductFilter filter)
        {
            return _productData.GetProducts(filter);
        }

        [HttpGet("sections")]
        public IEnumerable<Section> GetSections()
        {
            return _productData.GetSections();
        }
    }
}