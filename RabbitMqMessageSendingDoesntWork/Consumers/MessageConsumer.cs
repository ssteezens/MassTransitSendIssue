using System.Threading.Tasks;
using MassTransit;

namespace RabbitMqMessageSendingDoesntWork.Consumers;

public class MessageConsumer : IConsumer<Message>
{
    public async Task Consume(ConsumeContext<Message> context)
    {
        var receivedMessage = context.Message;
        
    }
}