using Microsoft.EntityFrameworkCore;

namespace Blogging_Backend
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }
        public DbSet<Post> Posts { get; set; }

    }
}
