using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebStore.Domain.Entities;
using WebStore.Domain.Filters;
using WebStore.DomainNew.Dto;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Clients.Services
{
    public class ProductsClient : BaseClient, IProductService
    {
        protected override string ServiceAddress { get; } = "api/products";
        public ProductsClient(IConfiguration configuration) : base(configuration)
        {
        }


        public IEnumerable<Brand> GetBrands()
        {
            string url = $"{ServiceAddress}/brands";
            return Get<List<Brand>>(url);
        }

        public ProductDto GetProductById(int id)
        {
            string url = $"{ServiceAddress}/{id}";
            return Get<ProductDto>(url);
        }

        public IEnumerable<ProductDto> GetProducts(ProductFilter filter)
        {
            string url = $"{ServiceAddress}";
            return Post(url, filter).Content.ReadAsAsync<IEnumerable<ProductDto>>().Result;
        }

        public IEnumerable<Section> GetSections()
        {
            string url = $"{ServiceAddress}/sections";
            return Get<List<Section>>(url);
        }
    }
}
