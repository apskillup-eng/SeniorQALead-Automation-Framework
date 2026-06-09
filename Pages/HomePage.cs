namespace SeniorQALead.Automation.Framework.Pages;

/// <summary>
/// Page Object for Home page after successful login.
/// </summary>
public class HomePage : BasePage
{
    private By SuccessMessage => By.ClassName("post-title");
    private By LogoutButton => By.XPath("//a[contains(text(), 'Logout')]");

    /// <summary>
    /// Checks if user is successfully logged in by verifying success message.
    /// </summary>
    public bool IsLoggedInSuccessfully()
    {
        return IsElementDisplayed(SuccessMessage);
    }

    /// <summary>
    /// Gets the success message text.
    /// </summary>
    public string GetSuccessMessageText()
    {
        return GetText(SuccessMessage);
    }

    /// <summary>
    /// Clicks logout button if available.
    /// </summary>
    public void Logout()
    {
        if (IsElementDisplayed(LogoutButton))
            Click(LogoutButton);
    }
}