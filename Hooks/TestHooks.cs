using Reqnroll;

namespace SeniorQALead.Automation.Framework.Hooks;

/// <summary>
/// Reqnroll hooks for test lifecycle management.
/// Handles driver initialization and cleanup for each scenario.
/// </summary>
[Binding]
public class TestHooks
{
    /// <summary>
    /// Executes before each scenario.
    /// Initializes WebDriver based on scenario tags.
    /// </summary>
    [BeforeScenario]
    public void BeforeScenario(ScenarioContext scenarioContext)
    {
        // Skip driver initialization for API-only tests
        if (scenarioContext.ScenarioInfo.Tags.Contains("api") && !scenarioContext.ScenarioInfo.Tags.Contains("ui"))
            return;

        var browserType = ConfigurationManager.GetBrowserType();
        var driver = DriverFactory.CreateDriver(browserType);
        DriverManager.SetDriver(driver);
    }

    /// <summary>
    /// Executes after each scenario.
    /// Closes browser and cleans up resources.
    /// </summary>
    [AfterScenario]
    public void AfterScenario(ScenarioContext scenarioContext)
    {
        // Only quit driver for UI tests
        if (!scenarioContext.ScenarioInfo.Tags.Contains("api") || scenarioContext.ScenarioInfo.Tags.Contains("ui"))
        {
            DriverManager.QuitDriver();
        }
    }
}