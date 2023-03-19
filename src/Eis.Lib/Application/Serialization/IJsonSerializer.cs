namespace Eis.Lib.Application.Serialization;

public interface IJsonSerializer
{
    string SerializeEvent(object message);
    TOutput? DeserializeObject<TOutput>(string message);
    Task<TOutput> DeserializeObjectAsync<TOutput>(string message, CancellationToken token);
}