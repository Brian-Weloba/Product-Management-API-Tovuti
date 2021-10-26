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
    }
}