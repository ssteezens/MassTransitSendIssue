using MassTransit;

namespace RabbitMqMessageSendingWorks.Consumers
{
    public class MessageConsumerDefinition :
        ConsumerDefinition<MessageConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<MessageConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(x => x.Intervals(10, 100, 500, 1000));
        }
    }
}