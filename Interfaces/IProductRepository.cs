using Ornek2.Api.Models;
using System.Collections.Generic;

namespace Ornek2.Api.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetList();
        public Product GetById(int id);

        public Product Createe(Product product);

        public void Update(Product product);
        public void Delete(int id);

    }
}
