namespace Eis.Lib.Domain.Entities;

public class EisEventInboxOutBox
{
    public string Id { get; set; } = string.Empty;
    public string EventId { get; set; } = string.Empty;
    public string TopicQueueName { get; set; } = string.Empty;
    public string EisEvent { get; set; } = string.Empty;
    public DateTime EventTimeStamp { get; set; }
    public string IsEventProcessed { get; set; } = string.Empty;
    public string InOut { get; set; } = string.Empty;
}