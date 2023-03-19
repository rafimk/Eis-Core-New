namespace Eis.Lib.Application.Options;

public class ApplicationOption
{
    public string Name { get; set; } = string.Empty;
    public string OutboundTopic { get; set;} = string.Empty;
    public string InboundQueue { get; set;} = string.Empty;
}