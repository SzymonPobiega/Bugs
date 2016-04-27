using NServiceBus;
using NServiceBus.Logging;

public class MessageAHandler : IHandleMessages<MessageA>
{
    static ILog logger = LogManager.GetLogger<MessageAHandler>();
    IBus bus;

    public MessageAHandler(IBus bus)
    {
        this.bus = bus;
    }
    public void Handle(MessageA message)
    {
        logger.Info("Hello from MessageAHandler");
        bus.Reply(new MessageB());
    }
}