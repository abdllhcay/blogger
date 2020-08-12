using Blogger.Core.Entities;
using Blogger.Core.Enums;
using Blogger.Core.Helpers.Filtering;
using Blogger.Core.Models.Post;
using Blogger.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

namespace Blogger.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        public PostService(IPostRepository repository, ICategoryRepository categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }

        public Post CreatePost(CreatePostModel model)
        {
            Post post = new Post
            {
                CategoryId = model.CategoryId,
                Content = model.Content,
                Id = Guid.NewGuid().ToString(),
                PublishDate = model.PublishDate,
                Status = (int)GeneralEnums.Status.Active,
                StatusReason = (int)PostEnums.StatusReason.Published,
                Summary = model.Summary,
                Title = model.Title
            };

            _repository.Add(post);
            return post;
        }

        public void DeletePost(string id)
        {
            _repository.Delete(id);
        }

        public ViewPostModel GetPost(string id)
        {
            var post = _repository.Get(id);

            return new ViewPostModel
            {
                Category = $"/api/categories/{post.CategoryId}",
                Content = post.Content,
                Id = post.Id,
                PublishDate = post.PublishDate,
                Status = post.Status,
                StatusReason = post.StatusReason,
                Summary = post.Summary,
                Title = post.Title
            };
        }

        public IEnumerable<ViewPostModel> GetPosts(GetPostsModel model)
        {
            var posts = _repository.GetAll();

            var filteredPosts = new FilterBuilder()
                .SetName(model.Title)
                .SetDate(model.Date)
                .SetStartDate(model.Start)
                .SetEndDate(model.End)
                .Build(posts);

            var result = new List<ViewPostModel>();
            filteredPosts.ToList().ForEach(post =>
            {
                result.Add(new ViewPostModel
                {
                    Category = $"/api/categories/{post.CategoryId}",
                    Content = post.Content,
                    Id = post.Id,
                    PublishDate = post.PublishDate,
                    Status = post.Status,
                    StatusReason = post.StatusReason,
                    Summary = post.Summary,
                    Title = post.Title
                });
            });

            return result;
        }

        public Post UpdatePost(string id, UpdatePostModel model)
        {
            Post post = new Post
            {
                CategoryId = model.CategoryId,
                Content = model.Content,
                Id = id,
                PublishDate = model.PublishDate,
                Status = (int)GeneralEnums.Status.Active,
                StatusReason = (int)PostEnums.StatusReason.Published,
                Summary = model.Summary,
                Title = model.Title
            };

            _repository.Update(post);
            return post;
        }
    }
}
