using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.company_drivers.Infrastructure.entity;

public sealed class CompanyDriversEntityConfiguration : IEntityTypeConfiguration<CompanyDriversEntity>
{
    public void Configure(EntityTypeBuilder<CompanyDriversEntity> builder)
    {
        builder.ToTable("company_drivers");
        builder.HasKey(x => new { x.CompanyId, x.DriverId });
        builder.Property(x => x.CompanyId).HasColumnName("company_id").IsRequired();
        builder.Property(x => x.DriverId).HasColumnName("driver_id").IsRequired();

        builder.HasOne(x => x.Company)
            .WithMany(x => x.CompanyDriverLinks)
            .HasForeignKey(x => x.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Driver)
            .WithMany(x => x.CompanyDriverLinks)
            .HasForeignKey(x => x.DriverId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
