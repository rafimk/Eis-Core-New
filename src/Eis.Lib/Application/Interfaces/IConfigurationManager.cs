using Eis.Lib.Application.Options;

namespace Eis.Lib.Application.Interfaces;

public interface IConfigurationManager
{
    string GetBrokerUrl();
    ApplicationOption GetAppSettings();
    ApplicationOption GetBrokerConfiguration();
    void Dispose();

    string GetSourceSystemName();
    bool GetMessageSubscriptionStatus();
}