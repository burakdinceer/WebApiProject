using Ornek2.Api.Data;
using Ornek2.Api.Interfaces;
using Ornek2.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ornek2.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public Product Createe(Product product)
        {
          _context.Products.Add(product);
           _context.SaveChanges();
            return product;
        }

        public void Delete(int id)
        {
            var deletProduct = _context.Products.Find(id);
            _context.Products.Remove(deletProduct);
            _context.SaveChanges();
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetList()
        {
            return _context.Products.ToList();
        }

        public void Update(Product product)
        {
            var degismemisProduct = _context.Products.Find(product.Id);
            _context.Entry(degismemisProduct).CurrentValues.SetValues(product);
            _context.SaveChanges();
            

        }
    }
}
