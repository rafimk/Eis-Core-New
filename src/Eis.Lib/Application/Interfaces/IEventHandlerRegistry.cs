namespace Eis.Lib.Application.Interfaces;

public interface IEventHandlerRegistry
{
    void AddMessageProcessor(IMessageProcessor messageProcessor);
    IMessageProcessor GetMessageProcessor();
}