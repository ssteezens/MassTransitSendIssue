using MassTransit;

namespace RabbitMqMessageSendingDoesntWork;

[EntityName("test-exchange")]
public class Message
{
    public string Thing { get; set; }
}