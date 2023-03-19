using Eis.Lib.Application.Dto;

namespace Eis.Lib.Application.Interfaces;

public interface IMessageProcessor
{
    Task Process(Payload payload, string eventType);
}