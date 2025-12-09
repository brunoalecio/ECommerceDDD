using ECommerceDDD.Domain.Interfaces;
using ECommerceDDD.Infra.Data.Context;
using ECommerceDDD.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceDDD.Infra.IoC.DependencyInjection
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            // DbContext
            services.AddDbContext<ECommerceDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IClienteRepository, ClienteRepository>();

            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
