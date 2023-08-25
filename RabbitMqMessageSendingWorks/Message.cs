using MassTransit;

namespace RabbitMqMessageSendingWorks;

[EntityName("test-exchange")]
public class Message
{
    public string Thing { get; set; }
}