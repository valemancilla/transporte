using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.load_status_history.Infrastructure.entity;

public sealed class LoadStatusHistoryEntityConfiguration : IEntityTypeConfiguration<LoadStatusHistoryEntity>
{
    public void Configure(EntityTypeBuilder<LoadStatusHistoryEntity> builder)
    {
        builder.ToTable("load_status_history");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.LoadId).HasColumnName("load_id").IsRequired();
        builder.Property(x => x.LoadStatusId).HasColumnName("load_status_id").IsRequired();
        builder.Property(x => x.ChangedAt).HasColumnName("changed_at").IsRequired();

        builder.HasOne(x => x.Load)
            .WithMany(x => x.LoadStatusHistories)
            .HasForeignKey(x => x.LoadId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
