using Microsoft.AspNetCore.Mvc;
using Ornek2.Api.Interfaces;
using Ornek2.Api.Models;
using Ornek2.Api.Services;
using System.Collections.Generic;
using System.Linq;

namespace Ornek2.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;
       
        public ProductsController(
            IProductRepository productRepository,
            IProductService productService)

        {
            _productRepository = productRepository;
            _productService = productService;
        }

        [HttpGet]
        [Route("GetList")]
       public IActionResult GetAll()
        {
            var list = _productRepository.GetList();

            return Ok(list);
        }


        [HttpGet]
        [Route("GetSimpleList")]
        public IActionResult GetSimpleList()
        {
            

            return Ok(_productService.GetSimpleList());
        }

        [HttpGet("{id}")]
        public IActionResult GetBy(int id)
        {
            var data = _productRepository.GetById(id);
            if(data == null)
            {
                return NotFound(id);
            }
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            var addedProduct = _productRepository.Createe(product);
            return Created("",addedProduct);
        }

        [HttpPut]
        public IActionResult Updates(Product product)
        {
            var kontrol = _productRepository.GetById(product.Id);
            if(kontrol == null)
            {
                return NotFound(product.Id);
            }
            _productRepository.Update(product);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Deletes(int id)
        {
            var getir = _productRepository.GetById(id);
            if (getir == null)
            {
                return NotFound(id);
            }
            _productRepository.Delete(id);
            return NoContent();
        }
    }
}
