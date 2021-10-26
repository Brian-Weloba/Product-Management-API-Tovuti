using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Entities;
using ProductManagementAPI.Repositories;

namespace ProductManagementAPI.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly InMemProductsRepository repository;

        public ProductsController()
        {
            repository = new InMemProductsRepository();
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            var products = repository.GetProducts();
            return products;
        }

        [HttpGet("{sku}")]
        public Product GetProduct(Guid sku){
            return repository.GetProduct(sku);
        }
    }
}