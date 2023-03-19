namespace Eis.Lib.Domain.Entities;

public class EisCompetingConsumerGroup
{
    public string Id { get; set; } = string.Empty;
    public string HostIpAddress { get; set; } = string.Empty;
    public DateTime LastAccessedTimeStamp { get; set; }
    public string GroupKey { get; set; } = string.Empty;
}