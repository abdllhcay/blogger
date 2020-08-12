using Blogger.Core.Models.Post;
using Blogger.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Blogger.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _service;
        public PostsController(IPostService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] GetPostsModel model)
        {
            try
            {
                var posts = _service.GetPosts(model);

                if (!posts.Any())
                {
                    return NoContent();
                }

                return Ok(posts);
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
                var post = _service.GetPost(id);

                if (post == null)
                {
                    return NoContent();
                }

                return Ok(post);
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
        public IActionResult Post([FromBody] CreatePostModel model)
        {
            try
            {
                var post = _service.CreatePost(model);

                return Ok(post);
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
        public IActionResult Put(string id, [FromBody] UpdatePostModel model)
        {
            try
            {
                var post = _service.UpdatePost(id, model);

                return Ok(post);
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

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
