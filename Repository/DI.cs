using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Plantsist.AppProGateway.Repository.Repositories.DbContext;
using Repository.Abstraction;
using Repository.DbContext;

namespace Repository;

public static class DI
{
    public static void AddRepository(this IServiceCollection serviceCollection,
        Action<DbContextOptionsBuilder> option)
    {
        serviceCollection.AddDbContext<DbEntities>(option);
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}