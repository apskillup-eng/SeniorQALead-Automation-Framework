using TechTalk.SpecFlow;

namespace SeniorQALead.Automation.Framework.StepDefinitions;

/// <summary>
/// Step definitions for Login feature.
/// Maps Gherkin steps to page object actions.
/// </summary>
[Binding]
public class LoginSteps
{
    private readonly LoginPage _loginPage;
    private readonly HomePage _homePage;

    public LoginSteps()
    {
        _loginPage = new LoginPage();
        _homePage = new HomePage();
    }

    [Given(@"I am on the login page")]
    public void GivenIAmOnTheLoginPage()
    {
        _loginPage.NavigateToLogin();
    }

    [When(@"I enter username ""(.*)""")]
    public void WhenIEnterUsername(string username)
    {
        _loginPage.EnterUsername(username);
    }

    [When(@"I enter password ""(.*)""")]
    public void WhenIEnterPassword(string password)
    {
        _loginPage.EnterPassword(password);
    }

    [When(@"I click the login button")]
    public void WhenIClickTheLoginButton()
    {
        _loginPage.ClickLogin();
    }

    [Then(@"I should see the success message")]
    public void ThenIShouldSeeTheSuccessMessage()
    {
        _loginPage.IsSuccessMessageDisplayed().Should().BeTrue("Success message should be displayed after successful login");
    }

    [Then(@"I should see an error message")]
    public void ThenIShouldSeeAnErrorMessage()
    {
        _loginPage.IsErrorMessageDisplayed().Should().BeTrue("Error message should be displayed for failed login");
    }
}