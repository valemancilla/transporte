using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.chat_messages.Infrastructure.entity;

public sealed class ChatMessagesEntityConfiguration : IEntityTypeConfiguration<ChatMessagesEntity>
{
    public void Configure(EntityTypeBuilder<ChatMessagesEntity> builder)
    {
        builder.ToTable("chat_messages");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.ChatRoomId).HasColumnName("chat_room_id").IsRequired();
        builder.Property(x => x.SenderId).HasColumnName("sender_id").IsRequired();
        builder.Property(x => x.MessageTypeId).HasColumnName("message_type_id");
        builder.Property(x => x.MessageContent).HasColumnName("message_content").HasColumnType("text").IsRequired();
        builder.Property(x => x.IsRead).HasColumnName("is_read").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();

        builder.HasOne(x => x.ChatRoom)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.ChatRoomId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Sender)
            .WithMany(x => x.SentChatMessages)
            .HasForeignKey(x => x.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.MessageType)
            .WithMany(x => x.ChatMessages)
            .HasForeignKey(x => x.MessageTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
