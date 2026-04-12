using transporte.src.modules.chat_rooms.Infrastructure.entity;
using transporte.src.modules.persons.Infrastructure.entity;

namespace transporte.src.modules.chat_participants.Infrastructure.entity;

public sealed class ChatParticipantsEntity
{
    public Guid ChatRoomId { get; set; }

    public Guid PersonId { get; set; }

    public DateTime JoinedAt { get; set; }

    public ChatRoomsEntity ChatRoom { get; set; } = null!;

    public PersonsEntity Person { get; set; } = null!;
}
