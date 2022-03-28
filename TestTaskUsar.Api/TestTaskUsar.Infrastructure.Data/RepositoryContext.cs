using Microsoft.EntityFrameworkCore;
using TestTaskUsar.Domain.Core;

namespace TestTaskUsar.Infrastructure.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
         : base(options)
        {
           // Database.EnsureCreated();
        }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}