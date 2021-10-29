using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Entities;
using ProductManagementAPI.Repositories;

namespace ProductManagementAPI.Controllers
{
    [ApiController]
    [Route("compositeProduct")]
    public class CompositeProductController: ControllerBase
    {
        private readonly ICompositeRepository _repo;

        public CompositeProductController(ICompositeRepository _repo)
        {
            this._repo = _repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompositeProduct>>> GetProducts()
        {
            var products = await _repo.GetCompositeProducts();
            return Ok(products);
        }

        [HttpGet("{sku}")]
        public async Task<ActionResult<CompositeProduct>> GetProduct(Guid sku)
        {

            var product = await _repo.GetCompositeProduct(sku);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<CompositeProduct>> CreateProduct(CompositeProduct product)
        {
            CompositeProduct productNew = new()
            {
                CompProduct = product.CompProduct,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Quantity = product.Quantity,
                CreatedDate = DateTimeOffset.UtcNow
            };
            await _repo.CreateCompositeProduct(productNew);
            return Ok();
        }

        [HttpPut("{sku}")]
        public async Task<ActionResult> UpdateProduct(Guid sku, CompositeProduct product)
        {
            CompositeProduct productUpdated = new()
            {
                CompProduct = product.CompProduct,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Quantity = product.Quantity,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await _repo.UpdateCompositeProduct(productUpdated);

            return Ok();
        }

        [HttpDelete("{sku}")]
        public async Task<ActionResult> DeleteProduct(Guid sku)
        {
            var existingProduct = _repo.GetCompositeProduct(sku);

            if (existingProduct is null)
            {
                return NoContent();
            }

            await _repo.DeleteCompositeProduct(sku);

            return Ok();

        }


        [HttpPut("{sku}/{categoryId}")]
        public async Task<ActionResult> SetCategory(Guid sku, Guid categoryId)
        {
            CompositeProduct updatedProduct = new()
            {
                SKU = sku,
                CategoryId = categoryId
            };

            await _repo.AddCategoryId(updatedProduct);
            return Ok();
        }

    }
}