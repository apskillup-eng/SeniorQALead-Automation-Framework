using TechTalk.SpecFlow;
using Newtonsoft.Json.Linq;

namespace SeniorQALead.Automation.Framework.StepDefinitions;

/// <summary>
/// Step definitions for API tests.
/// Demonstrates RestSharp v112+ usage for REST API testing.
/// </summary>
[Binding]
public class ApiSteps
{
    private RestResponse? _response;
    private readonly ApiClient _apiClient;

    public ApiSteps()
    {
        _apiClient = new ApiClient(ConfigurationManager.GetApiBaseUrl());
    }

    [When(@"I send a GET request to ""(.*)""")]
    public async Task WhenISendAGETRequestTo(string endpoint)
    {
        _response = await _apiClient.GetAsync(endpoint);
    }

    [When(@"I send a POST request to ""(.*)"" with body:")]
    public async Task WhenISendAPOSTRequestToWithBody(string endpoint, Table table)
    {
        var body = new Dictionary<string, object>();
        foreach (var row in table.Rows)
        {
            body[row[0]] = row[1];
        }
        _response = await _apiClient.PostAsync(endpoint, body);
    }

    [Then(@"the response status code should be (\d+)")]
    public void ThenTheResponseStatusCodeShouldBe(int statusCode)
    {
        _response.Should().NotBeNull("Response should not be null");
        ((int)_response!.StatusCode).Should().Be(statusCode, $"Expected status code {statusCode}, but got {(int)_response.StatusCode}");
    }

    [Then(@"the response should contain a title")]
    public void ThenTheResponseShouldContainATitle()
    {
        _response.Should().NotBeNull("Response should not be null");
        var json = JObject.Parse(_response!.Content ?? "{}");
        json["title"].Should().NotBeNull("Response should contain a 'title' field");
    }
}