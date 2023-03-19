using Eis.Lib.Application.Dto;
using Eis.Lib.Domain.Entities;

namespace Eis.Lib.Application.Interfaces;

public interface IEventInboxOutboxDbContext
{
    Task<List<EisEventInboxOutBox>> GetAllUnprocessedEvents(string direction, string topicQueueName);
    Task<int> TryEventInsert(EisEvent eisEvent, string topicQueueName, string direction);
    Task<int> UpdateEventStatus(string eventId, string topicQueueName, string eventStatus, string direction);
}