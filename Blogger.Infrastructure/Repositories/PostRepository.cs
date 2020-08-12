using Blogger.Core.Entities;
using Blogger.Infrastructure.Data;

namespace Blogger.Infrastructure.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(DataContext context) : base(context)
        {
        }
    }
}
