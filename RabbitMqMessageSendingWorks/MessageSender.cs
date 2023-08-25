using System;
using System.Threading.Tasks;
using MassTransit;

namespace RabbitMqMessageSendingWorks;

public class MessageSender : IMessageSender 
{
    private readonly ISendEndpointProvider _sendEndpointProvider;
    private readonly IRequestClient<Message> _client;

    public MessageSender(ISendEndpointProvider sendEndpointProvider, IRequestClient<Message> client)
    {
        _sendEndpointProvider = sendEndpointProvider;
        _client = client;
    }
    
    public async Task Send()
    {
        var endpoint = await
            _sendEndpointProvider.GetSendEndpoint(new Uri("queue:queue1", UriKind.RelativeOrAbsolute));
        
        await endpoint.Send(new Message() { Thing = "Hello" });
    }
}