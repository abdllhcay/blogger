using Blogger.Core.Entities;
using Blogger.Core.Enums;
using Blogger.Core.Models.Post;
using Blogger.Infrastructure.Repositories;
using System;
using System.Collections.Generic;

namespace Blogger.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;
        public PostService(IPostRepository repository)
        {
            _repository = repository;
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

        public Post GetPost(string id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Post> GetPosts()
        {
            return _repository.GetAll();
        }
    }
}
