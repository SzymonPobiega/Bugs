using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

public class MessageBHandler : IHandleMessages<MessageB>
{
    static ILog logger = LogManager.GetLogger<MessageBHandler>();

    public Task Handle(MessageB message, IMessageHandlerContext context)
    {
        logger.Info("Hello from MessageBHandler");
        return Task.FromResult(0);
    }
}