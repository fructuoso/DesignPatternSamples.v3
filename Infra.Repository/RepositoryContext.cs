using Microsoft.EntityFrameworkCore;

namespace DesignPatternSamples.Infra.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
