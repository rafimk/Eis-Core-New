namespace Eis.Lib.Application.Interfaces;

public interface IJobSchedule
{
    Type JobType { get; }
    
    string GetCronExpression();
}