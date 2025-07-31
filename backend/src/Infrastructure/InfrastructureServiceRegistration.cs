using Ecommerce.Application.Models.Token;
using Ecommerce.Application.Persistence;
using Ecommerce.Domain;
using Ecommerce.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Asn1.X509.Qualified;

namespace Ecommerce.Persistence;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Register your infrastructure services here
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IAsyncRepository<>),typeof(RepositoryBase<>));

        services.Configure<JwtSetting>(configuration.GetSection("jwtSettings"));

        // Add other necessary infrastructure services

        return services;
    }
}