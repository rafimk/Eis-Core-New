namespace Eis.Lib.Application.Options;

public class BrokerOptions
{
    public string Url { get; set;} = string.Empty;
    public string Username { get; set;} = string.Empty;
    public string Password { get; set;} = string.Empty;
    public string CronExpression { get; set;} = string.Empty;
    public int RefreshInterval { get; set;} = 1;
    public string InboxOutboxTimerPeriod { get; set;} = string.Empty;
}