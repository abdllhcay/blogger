using Blogger.Core.Entities;
using Blogger.Core.Models.Category;
using System.Collections.Generic;

namespace Blogger.Infrastructure.Services
{
    public interface ICategoryService
    {
        Category GetCategory(string id);
        IEnumerable<Category> GetCategories();
        Category CreateCategory(CreateCategoryModel model);
        Category UpdateCategory(string id, UpdateCategoryModel model);
        void DeleteCategory(string id);
    }
}
