using MassTransit;

namespace RabbitMqMessageSendingDoesntWork.Consumers
{
    public class SubmitOrderConsumerDefinition :
        ConsumerDefinition<MessageConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<MessageConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(x => x.Intervals(10, 100, 500, 1000));
        }
    }
}