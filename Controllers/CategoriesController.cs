using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Dtos;
using ProductManagementAPI.Entities;
using ProductManagementAPI.Repositories;

namespace ProductManagementAPI.Controllers
{
    [ApiController]
    [Route("productCategories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IProductsCategoryRepo repo;

        public CategoriesController(IProductsCategoryRepo repo)
        {
            this.repo = repo;
        }
        //GET /productCategories
        [HttpGet]
        public IEnumerable<CategoryDto> GetCategories()
        {
            var categories = repo.getProductCategories().Select(category => category.AsCategoryDto());
            return categories;
        }

        //GET /productCategories/{id}
        [HttpGet("{id}")]
        public ActionResult<CategoryDto> getCategory(int id)
        {
            var category = repo.GetProductCategory(id);

            if (category is null)
            {
                return NotFound();
            }

            return category.AsCategoryDto();

        }

        [HttpPost]
        public ActionResult<CategoryDto> CreateCAtegory(CreateCategoryDto categoryDto)
        {
            ProductCategory productCategory = new()
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };

            repo.CreateProductCategory(productCategory);

            return CreatedAtAction(nameof(GetCategories), new { id = categoryDto.Id }, productCategory.AsCategoryDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, UpdateCategoryDto categoryDto)
        {
            var existingCategory = repo.GetProductCategory(id);

            if (existingCategory is null)
            {
                return NotFound();
            }

            ProductCategory updatedCategory = existingCategory with
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };

            repo.UpdateProductCategory(updatedCategory);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var existingCategory =repo.GetProductCategory(id);

            if (existingCategory is null)
            {
                return NoContent();
            }

            repo.DeleteProductCategory(id);

            return NoContent();

        }

    }

}