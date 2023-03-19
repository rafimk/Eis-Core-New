using Eis.Lib.Application.Interfaces;
using Eis.Lib.Infrastructure.Scheduler.Jobs;

namespace Eis.Lib.Infrastructure.Scheduler;

public class InboxOutboxPollerJobSchedule : IJobSchedule
{
    private readonly IConfigurationManager _configManager;

    public InboxOutboxPollerJobSchedule(IConfigurationManager configManager)
    {
        _configManager = configManager;
        JobType = typeof(InboxOutboxPollerJob);

    }

    public Type JobType { get; }
    
    public string GetCronExpression()
    {
        return _configManager.GetBrokerConfiguration().InboxOutboxTimerPeriod;
    }
}