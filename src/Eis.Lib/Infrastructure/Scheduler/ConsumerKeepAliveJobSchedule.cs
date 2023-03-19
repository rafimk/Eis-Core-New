using Eis.Lib.Application.Interfaces;
using Eis.Lib.Infrastructure.Scheduler.Jobs;

namespace Eis.Lib.Infrastructure.Scheduler;

public class ConsumerKeepAliveJobSchedule : IJobSchedule 
{
    private readonly IConfigurationManager _configManager;

    public ConsumerKeepAliveJobSchedule(IConfigurationManager configManager)
    {
        _configManager = configManager;
        JobType = typeof(ConsumerKeepAliveEntryPollerJob);

    }

    public Type JobType { get; }
    
    public string GetCronExpression()
    {
        return _configManager.GetBrokerConfiguration().CronExpression;
    }
}