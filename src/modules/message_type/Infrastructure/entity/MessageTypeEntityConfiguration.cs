using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.message_type.Infrastructure.entity;

public sealed class MessageTypeEntityConfiguration : IEntityTypeConfiguration<MessageTypeEntity>
{
    public void Configure(EntityTypeBuilder<MessageTypeEntity> builder)
    {
        builder.ToTable("message_type");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
    }
}
