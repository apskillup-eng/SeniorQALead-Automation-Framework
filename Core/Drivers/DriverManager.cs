namespace SeniorQALead.Automation.Framework.Core.Drivers;

/// <summary>
/// Thread-safe driver manager using ThreadLocal storage.
/// Ensures each test thread has its own isolated WebDriver instance.
/// </summary>
public static class DriverManager
{
    private static readonly ThreadLocal<IWebDriver> DriverThreadLocal = new();

    /// <summary>
    /// Sets the WebDriver instance for the current thread.
    /// </summary>
    public static void SetDriver(IWebDriver driver) 
        => DriverThreadLocal.Value = driver;

    /// <summary>
    /// Gets the WebDriver instance for the current thread.
    /// </summary>
    public static IWebDriver GetDriver() 
        => DriverThreadLocal.Value ?? throw new InvalidOperationException(
            "Driver not initialized. Call SetDriver() in BeforeScenario hook.");

    /// <summary>
    /// Quits the WebDriver and clears ThreadLocal storage.
    /// </summary>
    public static void QuitDriver()
    {
        try
        {
            DriverThreadLocal.Value?.Quit();
        }
        finally
        {
            DriverThreadLocal.Value = null;
        }
    }
}