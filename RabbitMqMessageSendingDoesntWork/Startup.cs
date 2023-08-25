using System;
using MassTransit;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using RabbitMqMessageSendingDoesntWork;
using RabbitMqMessageSendingDoesntWork.Consumers;

[assembly: FunctionsStartup(typeof(Startup))]
namespace RabbitMqMessageSendingDoesntWork;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services
            .AddScoped<RabbitMqFunctionTest>()
            .AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();
                x.AddConsumersFromNamespaceContaining<ConsumerNamespace>();
                x.AddRequestClient<Message>(new Uri("queue:queue1"));

                x.UsingRabbitMq((context, cfg) => { cfg.ConfigureEndpoints(context); });
            })
            .AddScoped<IMessageSender, MessageSender>()
            .AddSingleton<IAsyncBusHandle, AsyncBusHandle>()
            .RemoveMassTransitHostedService();
    }
}