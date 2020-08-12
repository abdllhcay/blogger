using Blogger.Core.Entities;
using Blogger.Infrastructure.Data;

namespace Blogger.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }
    }
}
