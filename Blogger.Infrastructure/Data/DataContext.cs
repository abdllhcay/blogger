using Blogger.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}
