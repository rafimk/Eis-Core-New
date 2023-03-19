using System.Reflection;
using Eis.Lib.Application.Constants;
using Eis.Lib.Application.Interfaces;
using Eis.Lib.Application.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Eis.Lib.Infrastructure.Configuration;

public class ConfigurationManager : IConfigurationManager
{
    private bool isDisposed = false;
    private readonly ILogger<ConfigurationManager> _log;
    private readonly BrokerOptions _brokerOptions;
    private readonly ApplicationOption _applicationOption;
    private readonly IConfiguration _configuration;
    private string _sourceSystemName;
    private bool _messageSubscription;

    public ConfigurationManager(ILogger<ConfigurationManager> log, 
        IConfiguration configuration,
        IOptions<BrokerOptions> brokerOptions,
        IOptions<ApplicationOption> applicationOption
        )
    {
        _log = log;
        _log.LogInformation("Configuration manager constructor");
        _configuration = configuration;
        _brokerOptions = brokerOptions.Value;
        _applicationOption = applicationOption.Value;
        BindAppSettingsToObjects();
    }

    private void BindAppSettingsToObjects()
    {
        _log.LogInformation("Loading application configurations");

        var assembly = Assembly.GetExecutingAssembly();
        var brokerConfigurationClass = _brokerOptions;
        var applicationSettingsList = new List<ApplicationOption>();

        // If any environment profiles are set, bind settings from that file.
        var environment = _configuration["environment:profile"];
        _sourceSystemName = _configuration["eis:source-system-name"];
        _messageSubscription = _configuration["eis:messageSubscription"] == null ? true : _configuration["eis:messageSubscription"].Equals("true");

        string eisSettingsFileName = "EISCore.eissettings.json";
        _log.LogInformation("Loading assemblies");
        _log.LogInformation("Settings loading from {a}", eisSettingsFileName);
        Stream stream = assembly.GetManifestResourceStream(eisSettingsFileName);
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddJsonStream(stream);
        var configSectionFromFile = configurationBuilder.Build();
        configSectionFromFile.GetSection("ApplicationSettings").Bind(applicationSettingsList);
        var _appSetting = GetAppSettingsFromList(applicationSettingsList);

        GlobalVariables.IsMessageQueueSubscribed = _messageSubscription;

        if (environment != null)
        {
            eisSettingsFileName = eisSettingsFileName.Replace(".json", string.Empty) + "-" + environment.ToLower() + ".json";
            _log.LogInformation("Loading : {n}", eisSettingsFileName);
            stream = assembly.GetManifestResourceStream(eisSettingsFileName);
            configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonStream(stream);
            configSectionFromFile = configurationBuilder.Build();
            configSectionFromFile.GetSection("BrokerConfiguration").Bind(brokerConfigurationClass); // Bind broker settings to BrokerConfiguration class.
            _brokerConfiguration = brokerConfigurationClass;
        }
        else
        {
            _log.LogInformation("Environment is null, loading from : {n}", eisSettingsFileName);
            stream = assembly.GetManifestResourceStream(eisSettingsFileName);
            configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonStream(stream); 
            configSectionFromFile = configurationBuilder.Build();
            configSectionFromFile.GetSection("BrokerConfiguration").Bind(brokerConfigurationClass); // Bind broker settings to BrokerConfiguration class.
            _brokerConfiguration = brokerConfigurationClass;
        }
        stream.Close();
        _log.LogInformation("Consumer connection Quartz Job... Cron: [" + _brokerConfiguration.CronExpression + "]");
        _log.LogInformation("Inbox - Outbox      Quarts Job... Cron: [" + _brokerConfiguration.InboxOutboxTimerPeriod + "]");
    }

    public string GetBrokerUrl()
    {
        if (_brokerConfiguration != null)
        {
            return _brokerConfiguration.Url;
        }

        return null;
    }

    public ApplicationSettings GetAppSettingsFromList(List<ApplicationSettings> applicationSettingsList)
    {
        foreach (var appSettings in applicationSettingsList)
        {
            if (appSettings.Name.Equals(GetSourceSystemName()))
            {
                _log.LogDebug("Returning:: {a} : module settings", appSettings.Name);
                return appSettings;
            }
        }
        return null;
    }

    public bool GetMessageSubscriptionStatus() 
    {
        return _messageSubscription;
    }

    public BrokerConfiguration GetBrokerConfiguration()
    {
        return _brokerConfiguration;
    }

    public ApplicationSettings GetAppSettings()
    {
        return _appSettings;
    }

    public string GetSourceSystemName()
    {
        return _sourceSystemName;
    }

    #region 
    public void Dispose()
    {
        if (!isDisposed)
        {
            isDisposed = true;
        }
    }
    #endregion

}