using Microsoft.EntityFrameworkCore;
using Api.Classes;

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
