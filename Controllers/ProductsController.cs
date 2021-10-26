using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Dtos;
using ProductManagementAPI.Entities;
using ProductManagementAPI.Repositories;

namespace ProductManagementAPI.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository repository;

        public ProductsController(IProductsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<ProductDto> GetProducts()
        {
            var products = repository.GetProducts().Select(product => product.AsDto());
            return products;
        }

        [HttpGet("{sku}")]
        public ActionResult<ProductDto> GetProduct(Guid sku)
        {

            var product = repository.GetProduct(sku);
            if (product is null)
            {
                return NotFound();
            }

            return Ok(product.AsDto());
        }

        [HttpPost]
        public ActionResult<ProductDto> CreateProduct(CreateProductDto productDto)
        {
            Product product = new Product()
            {
                Name = productDto.Name,
                Brand = productDto.Brand,
                Price = productDto.Price,
                CreatedDate = DateTimeOffset.UtcNow,
                Vendor = productDto.Vendor,
                SKU = Guid.NewGuid()
            };
            repository.CreateProduct(product);

            return CreatedAtAction(nameof(GetProduct), new { sku = product.SKU }, product.AsDto());
        }
    }
}