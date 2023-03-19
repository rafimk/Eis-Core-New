namespace Eis.Lib.Application.Dto;

public class EisEvent
{
    public string EventId { get; set; } = string.Empty;
    public string EventType { get; set;} = string.Empty;
    public DateTime CreatedDate { get; set;} 
    public string SourceSystemName { get; set;} = string.Empty;
    public string TraceId { get; set;} = string.Empty;
    public string SpanId { get; set;} = string.Empty;
    public Payload Payload { get; set; } = new Payload();
}