using ECommerceDDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceDDD.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            // Mapeando Value Object (Email) -> coluna simples
            builder.OwnsOne(c => c.Email, email =>
            {
                email.Property(e => e.Address)
                    .HasColumnName("Email")
                    .HasMaxLength(200)
                    .IsRequired();
            });

            builder.Property(c => c.DataNascimento)
                .IsRequired();
        }
    }
}
