using Eis.Lib.Application.Dto;

namespace Eis.Lib.Application.Interfaces;

public interface IMessageEISProducer
{
    Payload GetPayLoad();
    string GetEventType();
    string GetTraceId();

}