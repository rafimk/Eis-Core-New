using Eis.Lib.Application.Dto;

namespace Eis.Lib.Application.Interfaces;

public interface IBrokerConnectionFactory
{
    void CreateConsumerListener();
    void DestroyConsumerConnection();
    void PublishTopic(EisEvent eisEvent);
}