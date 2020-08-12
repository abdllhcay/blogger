using System.Collections.Generic;

namespace Blogger.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(string id);
        T Get(string id);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}
