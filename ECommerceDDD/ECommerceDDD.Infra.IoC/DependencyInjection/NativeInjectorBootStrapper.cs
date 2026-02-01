using ECommerceDDD.Domain.Interfaces;
using ECommerceDDD.Infra.Data.Context;
using ECommerceDDD.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ECommerceDDD.Application.CommandHandlers;
using MediatR;
using ECommerceDDD.Infra.Data.Mongo;
using ECommerceDDD.Infra.Data.Mongo.Repositories;
using ECommerceDDD.Domain.Events;
using ECommerceDDD.Infra.Data.EventHandlers;

using System.Reflection;


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

            // MediatR
            services.AddMediatR(typeof(ClienteCommandHandler).Assembly);

            // MongoDB (Read Model)
            services.AddSingleton(sp =>
                new MongoContext(
                    "mongodb://mongodb:27017",
                    "ECommerceDDD_Read"
                ));

            services.AddScoped<ClienteReadRepository>();

            // Event Handlers
            services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();
        }
    }
}
