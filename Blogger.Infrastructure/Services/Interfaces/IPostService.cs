using Blogger.Core.Entities;
using Blogger.Core.Models.Post;
using System.Collections.Generic;

namespace Blogger.Infrastructure.Services
{
    public interface IPostService
    {
        ViewPostModel GetPost(string id);
        IEnumerable<ViewPostModel> GetPosts(GetPostsModel model);
        Post CreatePost(CreatePostModel model);
        Post UpdatePost(string id, UpdatePostModel model);
        void DeletePost(string id);
    }
}
