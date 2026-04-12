using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.chat_rooms.Infrastructure.entity;

public sealed class ChatRoomsEntityConfiguration : IEntityTypeConfiguration<ChatRoomsEntity>
{
    public void Configure(EntityTypeBuilder<ChatRoomsEntity> builder)
    {
        builder.ToTable("chat_rooms");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(150);
        builder.Property(x => x.TripId).HasColumnName("trip_id");
        builder.Property(x => x.LoadId).HasColumnName("load_id");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();

        builder.HasOne(x => x.Trip)
            .WithMany(x => x.ChatRooms)
            .HasForeignKey(x => x.TripId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Load)
            .WithMany(x => x.ChatRooms)
            .HasForeignKey(x => x.LoadId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
