using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DesignPatternSamples.Infra.Repository
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            optionsBuilder.UseSqlServer(@"(localdb)\MSSQLLocalDB");

            return new RepositoryContext(optionsBuilder.Options);
        }
    }
}
