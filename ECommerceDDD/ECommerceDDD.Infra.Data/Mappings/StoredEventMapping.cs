using ECommerceDDD.Infra.Data.EventSourcing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceDDD.Infra.Data.Mappings
{
    public class StoredEventMapping : IEntityTypeConfiguration<StoredEvent>
    {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.ToTable("StoredEvents");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Type)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Data)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder.Property(e => e.OccurredOn)
                .IsRequired();
        }
    }
}