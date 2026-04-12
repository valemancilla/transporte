using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.loads.Infrastructure.entity;

public sealed class LoadsEntityConfiguration : IEntityTypeConfiguration<LoadsEntity>
{
    public void Configure(EntityTypeBuilder<LoadsEntity> builder)
    {
        builder.ToTable("loads");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.CustomerId).HasColumnName("customer_id").IsRequired();
        builder.Property(x => x.TypeLoadId).HasColumnName("type_load_id").IsRequired();
        builder.Property(x => x.OriginCityId).HasColumnName("origin_city_id").IsRequired();
        builder.Property(x => x.DestinationCityId).HasColumnName("destination_city_id").IsRequired();
        builder.Property(x => x.OriginAddress).HasColumnName("origin_address").HasColumnType("text");
        builder.Property(x => x.DestinationAddress).HasColumnName("destination_address").HasColumnType("text");
        builder.Property(x => x.DestinationCoords).HasColumnName("destination_coords").HasColumnType("text");
        builder.Property(x => x.Weight).HasColumnName("weight").HasColumnType("decimal(10,2)").IsRequired();
        builder.Property(x => x.Volume).HasColumnName("volume").HasColumnType("decimal(10,2)").IsRequired();
        builder.Property(x => x.Price).HasColumnName("price").HasColumnType("decimal(15,2)").IsRequired();
        builder.Property(x => x.LoadStatusId).HasColumnName("load_status_id").IsRequired();
        builder.Property(x => x.PickupTime).HasColumnName("pickup_time");

        builder.HasOne(x => x.Customer)
            .WithMany(x => x.LoadsAsCustomer)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.TypeLoad)
            .WithMany(x => x.Loads)
            .HasForeignKey(x => x.TypeLoadId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.OriginCity)
            .WithMany(x => x.LoadsAsOrigin)
            .HasForeignKey(x => x.OriginCityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.DestinationCity)
            .WithMany(x => x.LoadsAsDestination)
            .HasForeignKey(x => x.DestinationCityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
