﻿using Blogger.Core.Entities;
using Blogger.Core.Models.Post;
using System.Collections.Generic;

namespace Blogger.Infrastructure.Services
{
    public interface IPostService
    {
        Post GetPost(string id);
        IEnumerable<Post> GetPosts();
        Post CreatePost(CreatePostModel model);
    }
}