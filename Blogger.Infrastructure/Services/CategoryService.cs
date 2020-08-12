using Blogger.Core.Entities;
using Blogger.Core.Models.Category;
using Blogger.Infrastructure.Repositories;
using System;
using System.Collections.Generic;

namespace Blogger.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Category CreateCategory(CreateCategoryModel model)
        {
            Category category = new Category
            {
                Name = model.Name,
                Id = Guid.NewGuid().ToString(),
            };

            _repository.Add(category);
            return category;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _repository.GetAll();
        }

        public Category GetCategory(string id)
        {
            return _repository.Get(id);
        }
    }
}
