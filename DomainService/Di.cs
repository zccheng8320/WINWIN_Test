using Microsoft.Extensions.DependencyInjection;
using Repository.Abstraction;

namespace DomainService;

public static class DI
{
    public static void AddDomainService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserService, UserService>();
    }
}