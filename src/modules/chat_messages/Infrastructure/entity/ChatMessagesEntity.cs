using transporte.src.modules.chat_rooms.Infrastructure.entity;
using transporte.src.modules.message_type.Infrastructure.entity;
using transporte.src.modules.persons.Infrastructure.entity;

namespace transporte.src.modules.chat_messages.Infrastructure.entity;

public sealed class ChatMessagesEntity
{
    public Guid Id { get; set; }

    public Guid ChatRoomId { get; set; }

    public Guid SenderId { get; set; }

    public Guid? MessageTypeId { get; set; }

    public string MessageContent { get; set; } = string.Empty;

    public bool IsRead { get; set; }

    public DateTime CreatedAt { get; set; }

    public ChatRoomsEntity ChatRoom { get; set; } = null!;

    public PersonsEntity Sender { get; set; } = null!;

    public MessageTypeEntity? MessageType { get; set; }
}
