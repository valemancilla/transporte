using transporte.src.modules.chat_messages.Infrastructure.entity;

namespace transporte.src.modules.message_type.Infrastructure.entity;

public sealed class MessageTypeEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<ChatMessagesEntity> ChatMessages { get; set; } = new List<ChatMessagesEntity>();
}
