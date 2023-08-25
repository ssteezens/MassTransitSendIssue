using System.Threading.Tasks;

namespace RabbitMqMessageSendingWorks;

public interface IMessageSender
{
    Task Send();
}