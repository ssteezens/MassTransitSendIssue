using System.Threading.Tasks;

namespace RabbitMqMessageSendingDoesntWork;

public interface IMessageSender
{
    Task Send();
}