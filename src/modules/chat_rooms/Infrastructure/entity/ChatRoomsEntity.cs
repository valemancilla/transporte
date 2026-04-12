using transporte.src.modules.chat_messages.Infrastructure.entity;
using transporte.src.modules.chat_participants.Infrastructure.entity;
using transporte.src.modules.loads.Infrastructure.entity;
using transporte.src.modules.trips.Infrastructure.entity;

namespace transporte.src.modules.chat_rooms.Infrastructure.entity;

public sealed class ChatRoomsEntity
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public Guid? TripId { get; set; }

    public Guid? LoadId { get; set; }

    public DateTime CreatedAt { get; set; }

    public TripsEntity? Trip { get; set; }

    public LoadsEntity? Load { get; set; }

    public ICollection<ChatParticipantsEntity> Participants { get; set; } = new List<ChatParticipantsEntity>();

    public ICollection<ChatMessagesEntity> Messages { get; set; } = new List<ChatMessagesEntity>();
}
