namespace Eis.Lib.Application.Interfaces;

public interface IEventPublisherService
{
    Task Publish(IMessageEISProducer messageObject);
}