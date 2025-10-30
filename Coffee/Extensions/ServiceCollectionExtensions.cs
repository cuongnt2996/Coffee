using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Coffee.Data;
using Coffee.Repositories;
using Coffee.Services;

namespace Coffee.Extensions;

/// <summary>
/// Centralizes dependency registration for the application.
/// Keep registrations grouped so Program.cs stays clean.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Register infrastructure-level services (DB connection factories, open-generic repos, etc.).
    /// </summary>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Db connection factory needs IConfiguration to read connection string
        services.AddSingleton<IDbConnectionFactory>(_ => new DbConnectionFactory(configuration));

        // Open generic repository mapping
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

        return services;
    }

    /// <summary>
    /// Register concrete repositories that have custom methods.
    /// </summary>
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        return services;
    }

    /// <summary>
    /// Register application services (business logic layer).
    /// </summary>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddSingleton<ISiteProvider, SiteProvider>();
        return services;
    }
}
