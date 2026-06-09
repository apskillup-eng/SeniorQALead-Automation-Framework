using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeniorQALead.Automation.Framework.Core.Drivers;

/// <summary>
/// Factory class responsible for creating WebDriver instances.
/// Supports Chrome and Firefox browsers with headless mode option.
/// </summary>
public class DriverFactory
{
    /// <summary>
    /// Creates a WebDriver instance based on the configured browser type.
    /// </summary>
    public static IWebDriver CreateDriver(string browserType = "Chrome")
    {
        var headless = ConfigurationManager.GetHeadless();

        return browserType.ToLower() switch
        {
            "chrome" => CreateChromeDriver(headless),
            "firefox" => CreateFirefoxDriver(headless),
            _ => CreateChromeDriver(headless)
        };
    }

    /// <summary>
    /// Creates Chrome WebDriver with automatic driver management.
    /// </summary>
    private static IWebDriver CreateChromeDriver(bool headless)
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        var options = new ChromeOptions();
        
        if (headless)
            options.AddArgument("--headless=new");
        
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        
        return new ChromeDriver(options);
    }

    /// <summary>
    /// Creates Firefox WebDriver with automatic driver management.
    /// </summary>
    private static IWebDriver CreateFirefoxDriver(bool headless)
    {
        new DriverManager().SetUpDriver(new FirefoxConfig());
        var options = new FirefoxOptions();
        
        if (headless)
            options.AddArgument("--headless");
        
        return new FirefoxDriver(options);
    }
}