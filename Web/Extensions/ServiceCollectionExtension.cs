using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Web.Common.Data.Abstract;
using Web.Data.Context;
using Web.Data.Repositories;

namespace Web.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddDbContext<AppDbContextReadonly>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnectionReadonly"));
        });

        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        return services;
    }

    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}