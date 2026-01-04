using FastEndpoint.Model;
using Microsoft.EntityFrameworkCore;

namespace FastEndpoint.dbContext
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
