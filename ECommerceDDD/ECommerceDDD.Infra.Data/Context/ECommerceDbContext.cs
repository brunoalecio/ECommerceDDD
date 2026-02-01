using ECommerceDDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ECommerceDDD.Infra.Data.EventSourcing;

namespace ECommerceDDD.Infra.Data.Context
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options) { }

        // DbSets (tabelas)
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<StoredEvent> StoredEvents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica todos os mapeamentos (que criaremos na próxima etapa)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ECommerceDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
