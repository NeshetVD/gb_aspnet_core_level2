using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;
using WebStore.Domain.Filters;
using WebStore.DomainNew.Dto;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Section> GetSections();
        IEnumerable<Brand> GetBrands();
        IEnumerable<ProductDto> GetProducts(ProductFilter filter);

        /// <summary>
        /// Получить товар по Id
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Сущность Product, если нашел, иначе null</returns>
        ProductDto GetProductById(int id);
    }
}