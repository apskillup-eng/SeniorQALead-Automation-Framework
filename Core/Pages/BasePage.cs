using OpenQA.Selenium.Support.UI;

namespace SeniorQALead.Automation.Framework.Core.Pages;

/// <summary>
/// Base Page Object class providing common methods for all page objects.
/// Implements implicit and explicit wait strategies.
/// </summary>
public class BasePage
{
    protected IWebDriver Driver => DriverManager.GetDriver();
    protected WebDriverWait Wait => new(Driver, TimeSpan.FromSeconds(ConfigurationManager.GetExplicitWait()));

    /// <summary>
    /// Navigates to the specified URL and maximizes the window.
    /// </summary>
    public virtual void Navigate(string url)
    {
        Driver.Navigate().GoToUrl(url);
        Driver.Manage().Window.Maximize();
    }

    /// <summary>
    /// Waits for an element to be present in the DOM.
    /// </summary>
    public virtual void WaitForElement(By locator)
    {
        Wait.Until(ExpectedConditions.PresenceOfElementLocated(locator));
    }

    /// <summary>
    /// Clicks on an element after waiting for it to be clickable.
    /// </summary>
    public virtual void Click(By locator)
    {
        Wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
    }

    /// <summary>
    /// Types text into an input field after clearing existing content.
    /// </summary>
    public virtual void Type(By locator, string text)
    {
        var element = Wait.Until(ExpectedConditions.PresenceOfElementLocated(locator));
        element.Clear();
        element.SendKeys(text);
    }

    /// <summary>
    /// Gets the text content of an element.
    /// </summary>
    public virtual string GetText(By locator)
    {
        WaitForElement(locator);
        return Driver.FindElement(locator).Text;
    }

    /// <summary>
    /// Checks if an element is displayed on the page.
    /// </summary>
    public virtual bool IsElementDisplayed(By locator)
    {
        try
        {
            return Driver.FindElement(locator).Displayed;
        }
        catch { return false; }
    }

    /// <summary>
    /// Scrolls to an element to make it visible.
    /// </summary>
    public virtual void ScrollToElement(By locator)
    {
        var element = Driver.FindElement(locator);
        ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }
}