namespace SeniorQALead.Automation.Framework.Pages;

/// <summary>
/// Page Object for Login functionality.
/// Demonstrates Page Object Model pattern with encapsulated elements and actions.
/// </summary>
public class LoginPage : BasePage
{
    private By UsernameInput => By.Id("username");
    private By PasswordInput => By.Id("password");
    private By LoginButton => By.Id("submit");
    private By ErrorMessage => By.Id("error");
    private By SuccessMessage => By.ClassName("post-title");

    /// <summary>
    /// Navigates to the login page.
    /// </summary>
    public void NavigateToLogin()
    {
        Navigate(ConfigurationManager.GetAppBaseUrl());
    }

    /// <summary>
    /// Enters username in the username input field.
    /// </summary>
    public void EnterUsername(string username)
    {
        Type(UsernameInput, username);
    }

    /// <summary>
    /// Enters password in the password input field.
    /// </summary>
    public void EnterPassword(string password)
    {
        Type(PasswordInput, password);
    }

    /// <summary>
    /// Clicks the login button.
    /// </summary>
    public void ClickLogin()
    {
        Click(LoginButton);
    }

    /// <summary>
    /// Performs complete login operation with username and password.
    /// </summary>
    public void Login(string username, string password)
    {
        EnterUsername(username);
        EnterPassword(password);
        ClickLogin();
    }

    /// <summary>
    /// Checks if error message is displayed.
    /// </summary>
    public bool IsErrorMessageDisplayed()
    {
        return IsElementDisplayed(ErrorMessage);
    }

    /// <summary>
    /// Checks if success message is displayed after login.
    /// </summary>
    public bool IsSuccessMessageDisplayed()
    {
        Thread.Sleep(1000); // Wait for page load
        return IsElementDisplayed(SuccessMessage);
    }
}