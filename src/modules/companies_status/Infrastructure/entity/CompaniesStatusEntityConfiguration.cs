using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.companies_status.Infrastructure.entity;

public sealed class CompaniesStatusEntityConfiguration : IEntityTypeConfiguration<CompaniesStatusEntity>
{
    public void Configure(EntityTypeBuilder<CompaniesStatusEntity> builder)
    {
        builder.ToTable("companies_status");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
    }
}