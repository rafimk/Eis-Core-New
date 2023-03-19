using System.Text.Json;
using System.Text.Json.Serialization;
using Eis.Lib.Application.Behavior;

namespace Eis.Lib.Application.Serialization;

public class SystemTextJsonSerializer : IJsonSerializer
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters =
        {
            new DateTimeJsonBehavior(),
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
        }
    };
    
    public string SerializeEvent(object message)
    {
        return JsonSerializer.Serialize(message, _options);
    }

    public TOutput? DeserializeObject<TOutput>(string message)
    {
        try
        {
            return JsonSerializer.Deserialize<TOutput>(message, _options);
        }
        catch
        {
            throw;
        }
    }

    public async Task<TOutput> DeserializeObjectAsync<TOutput>(string message, CancellationToken token)
    {
        try
        {
            byte[] byteArray = JsonSerializer.SerializeToUtf8Bytes(message);
            Stream memoryStream = new MemoryStream(byteArray);
            var awaitedComponent = await JsonSerializer.DeserializeAsync<TOutput>(memoryStream, _options, token);

            if (awaitedComponent == null)
            {
                Console.WriteLine("Payload is null");
            }

            return awaitedComponent!;

        }
        catch
        {
            await Console.Out.WriteLineAsync("Error occurred while converting to JSON");
            throw;
        }
    }
}