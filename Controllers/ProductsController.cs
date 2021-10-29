using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Dtos;
using ProductManagementAPI.Entities;
using ProductManagementAPI.Repositories;

namespace ProductManagementAPI.Controllers
{
    //
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _repo;
        private readonly IAttributeRepository _attRepo;
        private readonly ICategoryRepository _catRepo;

        public ProductsController(IProductRepository _repo, IAttributeRepository _attRepo, ICategoryRepository _catRepo)
        {
            this._repo = _repo;
            this._attRepo = _attRepo;
            this._catRepo = _catRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _repo.GetProducts();
            return Ok(products);
        }

        //GET /products/{sku}
        [HttpGet("product/{sku}")]
        public async Task<ActionResult<ProductDto>> GetProduct(Guid sku)
        {

            var product = await _repo.GetProduct(sku);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product.AsProductDto());
        }

        [HttpGet("{categoryId}")]
        public async Task<ActionResult<ProductDto>> GetProductByCategory(Guid categoryId)
        {
            var products = await _repo.GetProductByCategory(categoryId);
            return Ok(products);
        }

        //POST /products
        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto productDto)
        {
            Product product = new()
            {
                Name = productDto.Name,
                Brand = productDto.Brand,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
                CreatedDate = DateTimeOffset.UtcNow
            };
            await _repo.CreateProduct(product);
            return Ok();
        }

        //PUT /products/{sku}
        [HttpPut("{sku}")]
        public async Task<ActionResult> UpdateProduct(Guid sku, UpdateProductDto productDto)
        {
            Product updatedProduct = new()
            {
                SKU = sku,
                Name = productDto.Name,
                Brand = productDto.Brand,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
            };

            await _repo.UpdateProduct(updatedProduct);

            return Ok();
        }
        //DELETE /products/{sku}
        [HttpDelete("{sku}")]
        public async Task<ActionResult> DeleteProduct(Guid sku)
        {
            var existingProduct = _repo.GetProduct(sku);

            if (existingProduct is null)
            {
                return NoContent();
            }

            await _repo.DeleteProduct(sku);

            return Ok();

        }

        [HttpPut("/productAttributes")]
        public async Task<ActionResult> AddAttributes(Guid sku, CreateAttributeDto productDto)
        {
            // var existingProduct =await _repo.GetProduct(sku);

            // if (existingProduct is null)
            // {
            //     return NotFound();
            // }
            ProductAttributes updatedProduct = new()
            {
                ProductSKU = sku,
                Name = productDto.Name,
                Attributes = productDto.Attributes
            };

            await _attRepo.CreateAttribute(updatedProduct);

            return Ok();
        }

        [HttpPut("{sku}/{categoryId}")]
        public async Task<ActionResult> SetCategory(Guid sku,Guid categoryId)
        {
            Product updatedProduct = new()
            {
                SKU = sku,
                CategoryId = categoryId
            };

            await _repo.AddCategoryId(updatedProduct);
            return Ok();
        }

    }
}