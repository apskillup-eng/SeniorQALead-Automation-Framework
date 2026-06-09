using Microsoft.Extensions.Configuration;

namespace SeniorQALead.Automation.Framework.Core.Configuration;

/// <summary>
/// Centralized configuration management for test automation framework.
/// Loads configuration from appsettings.json and environment variables.
/// </summary>
public class ConfigurationManager
{
    private static IConfiguration? _configuration;

    /// <summary>
    /// Gets or initializes the configuration builder.
    /// </summary>
    public static IConfiguration GetConfiguration()
    {
        _configuration ??= new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("Config/appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();
        return _configuration;
    }

    public static string GetBrowserType() 
        => Environment.GetEnvironmentVariable("BROWSER_TYPE") 
        ?? GetConfiguration()["Browser:Type"] ?? "Chrome";

    public static bool GetHeadless() 
        => bool.Parse(GetConfiguration()["Browser:Headless"] ?? "false");

    public static int GetImplicitWait() 
        => int.Parse(GetConfiguration()["Browser:ImplicitWait"] ?? "10");

    public static int GetExplicitWait() 
        => int.Parse(GetConfiguration()["Browser:ExplicitWait"] ?? "30");

    public static string GetAppBaseUrl() 
        => Environment.GetEnvironmentVariable("APP_BASE_URL") 
        ?? GetConfiguration()["Application:BaseUrl"] ?? "";

    public static string GetApiBaseUrl() 
        => Environment.GetEnvironmentVariable("API_BASE_URL") 
        ?? GetConfiguration()["Application:ApiBaseUrl"] ?? "";

    public static string GetTestUsername() 
        => Environment.GetEnvironmentVariable("TEST_USERNAME") 
        ?? GetConfiguration()["TestData:ValidUsername"] ?? "student";

    public static string GetTestPassword() 
        => Environment.GetEnvironmentVariable("TEST_PASSWORD") 
        ?? GetConfiguration()["TestData:ValidPassword"] ?? "Password123";
}