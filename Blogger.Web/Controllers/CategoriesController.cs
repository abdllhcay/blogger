using Blogger.Core.Models.Category;
using Blogger.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Blogger.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var categories = _service.GetCategories();

                if (!categories.Any())
                {
                    return NoContent();
                }

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return new ContentResult
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Content = ex.Message,
                    ContentType = "text/plain",
                };
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var category = _service.GetCategory(id);

                if (category == null)
                {
                    return NoContent();
                }

                return Ok(category);
            }
            catch (Exception ex)
            {
                return new ContentResult
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Content = ex.Message,
                    ContentType = "text/plain",
                };
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateCategoryModel model)
        {
            try
            {
                var category = _service.CreateCategory(model);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return new ContentResult
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Content = ex.Message,
                    ContentType = "text/plain",
                };
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
