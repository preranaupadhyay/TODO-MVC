using Microsoft.EntityFrameworkCore;
using TODOApp.Models;

namespace TODOApp.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Todo> Todo { get; set; }
    }
}
