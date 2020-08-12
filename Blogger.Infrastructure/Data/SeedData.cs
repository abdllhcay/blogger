using Blogger.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blogger.Infrastructure.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context=new DataContext(serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
            {
                if (context.Posts.Any() && context.Categories.Any())
                {
                    return;
                }

                context.Posts.AddRange(
                    new Post
                    {
                        Category = "1",
                        Content = "In bibendum, dui tristique blandit suscipit, odio arcu ornare mauris, ac ultrices dolor lorem at ante. ",
                        Id = "1",
                        PublishDate = new DateTime(2020, 6, 20, 18, 12, 0),
                        Status = 0,
                        StatusReason = 0,
                        Summary = "",
                        Title = "In bibendum, dui tristiqu"
                    },
                    new Post
                    {
                        Category = "2",
                        Content = "Cras elit tortor, ultrices sit amet facilisis eu, dapibus eu metus. Aenean vestibulum turpis felis, eget tempus arcu sodales non.",
                        Id = "2",
                        PublishDate = new DateTime(2020, 8, 20, 18, 12, 0),
                        Status = 0,
                        StatusReason = 0,
                        Summary = "",
                        Title = "Cras elit tortor"
                    },
                    new Post
                    {
                        Category = "1",
                        Content = "Vivamus massa nunc, lobortis pellentesque dignissim blandit, aliquam porttitor orci. Sed eu libero quis turpis porttitor tincidunt. ",
                        Id = "3",
                        PublishDate = new DateTime(2020, 8, 10, 18, 12, 0),
                        Status = 0,
                        StatusReason = 0,
                        Summary = "",
                        Title = "Vivamus massa nunc"
                    }
                );

                context.Categories.AddRange(
                    new Category
                    {
                        Id = "1",
                        Name = "Business"
                    },
                    new Category
                    {
                        Id = "2",
                        Name = "Science"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
