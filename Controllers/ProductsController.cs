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

            return product.AsDto();
        }

        [HttpPost]
        public ActionResult<ProductDto> CreateProduct(CreateProductDto productDto)
        {
            Product product = new()
            {
                Name = productDto.Name,
                Brand = productDto.Brand,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
                CreatedDate = DateTimeOffset.UtcNow
            };
            repository.CreateProduct(product);

            return CreatedAtAction(nameof(GetProduct), new { sku = product.SKU }, product.AsDto());
        }

        [HttpPut("{sku}")]
        public ActionResult UpdateProduct(Guid sku, UpdateProductDto productDto)
        {
            var existingProduct = repository.GetProduct(sku);

            if (existingProduct is null)
            {
                return NotFound();
            }

            Product updatedProduct = existingProduct with
            {
                Name = productDto.Name,
                Brand = productDto.Brand,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
            };

            repository.UpdateProduct(updatedProduct);

            return NoContent();
        }

        [HttpDelete("{sku}")]
        public ActionResult DeleteProduct(Guid sku)
        {
            var existingProduct = repository.GetProduct(sku);

            if(existingProduct is null) {
                return NoContent();
            }

            repository.DeleteProduct(sku);

            return NoContent();

        }
    }
}