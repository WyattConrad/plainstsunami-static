using Microsoft.EntityFrameworkCore;
using BlazorApp.Shared;

namespace Api
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Team> Teams { get; set; }
    }
}
