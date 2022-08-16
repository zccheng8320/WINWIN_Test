using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Plantsist.AppProGateway.Repository.Repositories.DbContext;

namespace Plantsist.AppProGateway.Repository.EFCore;

internal class MasterDbContextFactory : IDesignTimeDbContextFactory<DbEntities>
{
    public DbEntities CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DbEntities>();
        optionsBuilder.UseSqlServer(args[0]);
        return new DbEntities(optionsBuilder.Options);
    }
}