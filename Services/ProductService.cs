using Ornek2.Api.Interfaces;
using Ornek2.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ornek2.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<Product> GetSimpleList()
        {

            var list = _productRepository.GetList().Where(x => x.Id > 25
            && x.Name.ToLower() == "burak"
            && x.Price > 50
            && x.Price < 100
            ).Select(a => new Product
            {
                Name = a.Name,
                Id = a.Id,
            }).ToList();
            return list;



        }
    }
}
