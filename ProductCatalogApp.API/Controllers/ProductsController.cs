using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogApp.API.Data;
using ProductCatalogApp.API.Dtos;
using ProductCatalogApp.API.Models;

namespace ProductCatalogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;
        public ProductsController(IProductRepository productRepo, IMapper mapper)
        {
            _mapper = mapper;
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
        [HttpPost("create")]
        public async Task<IActionResult> Create(ProductForCreateDto productForCreateDto)
        {
            //validate request
            if (await _productRepo.ProductExists(productForCreateDto.Name))
                return BadRequest("Product already exists");
            var productToCreate = _mapper.Map<Product>(productForCreateDto);
            var createdProduct = await _productRepo.Add(productToCreate);
            return StatusCode(201);
        }
    }
}