using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogApp.API.Data;

namespace ProductCatalogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        public ProductsController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        // /api/product
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productRepo.GetProducts();
            return Ok(products);
        }

        // POST api/product
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}