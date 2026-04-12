using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.chat_participants.Infrastructure.entity;

public sealed class ChatParticipantsEntityConfiguration : IEntityTypeConfiguration<ChatParticipantsEntity>
{
    public void Configure(EntityTypeBuilder<ChatParticipantsEntity> builder)
    {
        builder.ToTable("chat_participants");

        builder.HasKey(x => new { x.ChatRoomId, x.PersonId });
        builder.Property(x => x.ChatRoomId).HasColumnName("chat_room_id").IsRequired();
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.JoinedAt).HasColumnName("joined_at").IsRequired();

        builder.HasOne(x => x.ChatRoom)
            .WithMany(x => x.Participants)
            .HasForeignKey(x => x.ChatRoomId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Person)
            .WithMany(x => x.ChatParticipations)
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
