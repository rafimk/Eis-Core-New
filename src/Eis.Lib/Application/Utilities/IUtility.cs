using Eis.Lib.Application.Dto;
using Eis.Lib.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Eis.Lib.Application.Utilities;

public interface IUtility
{
    string? GetLocalIpAddress();
    Task ConsumeEventAsync(EisEvent eisEvent, string queueName, IEventHandlerRegistry eventRegistry, ILogger log);
}