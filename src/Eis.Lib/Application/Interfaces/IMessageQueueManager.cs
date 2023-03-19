using Eis.Lib.Application.Dto;

namespace Eis.Lib.Application.Interfaces;

public interface IMessageQueueManager
{
    Task ConsumerEvent(EisEvent eisEvent, string queueName);
    Task InboxOutboxPollerTask();
    Task TryPublish(EisEvent eisEvent);
    Task ConsumerKeepAliveTask();
}