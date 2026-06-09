using Newtonsoft.Json;
using RestSharp;

namespace SeniorQALead.Automation.Framework.Core.Api;

/// <summary>
/// REST API client wrapper using RestSharp v112+ (post-overhaul).
/// Provides fluent interface for common HTTP operations.
/// </summary>
public class ApiClient
{
    private readonly RestClient _client;

    public ApiClient(string baseUrl)
    {
        _client = new RestClient(baseUrl);
    }

    /// <summary>
    /// Sends a GET request to the specified endpoint.
    /// </summary>
    public async Task<RestResponse> GetAsync(string endpoint)
    {
        var request = new RestRequest(endpoint, Method.Get);
        return await _client.ExecuteAsync(request);
    }

    /// <summary>
    /// Sends a POST request with JSON body.
    /// </summary>
    public async Task<RestResponse> PostAsync(string endpoint, object body)
    {
        var request = new RestRequest(endpoint, Method.Post);
        request.AddJsonBody(body);
        return await _client.ExecuteAsync(request);
    }

    /// <summary>
    /// Sends a PUT request with JSON body.
    /// </summary>
    public async Task<RestResponse> PutAsync(string endpoint, object body)
    {
        var request = new RestRequest(endpoint, Method.Put);
        request.AddJsonBody(body);
        return await _client.ExecuteAsync(request);
    }

    /// <summary>
    /// Sends a DELETE request to the specified endpoint.
    /// </summary>
    public async Task<RestResponse> DeleteAsync(string endpoint)
    {
        var request = new RestRequest(endpoint, Method.Delete);
        return await _client.ExecuteAsync(request);
    }

    /// <summary>
    /// Generic GET request that deserializes response to specified type.
    /// </summary>
    public async Task<T?> GetAsync<T>(string endpoint)
    {
        var response = await GetAsync(endpoint);
        return response.IsSuccessful 
            ? JsonConvert.DeserializeObject<T>(response.Content ?? "{}")
            : default(T);
    }

    /// <summary>
    /// Generic POST request that deserializes response to specified type.
    /// </summary>
    public async Task<T?> PostAsync<T>(string endpoint, object body)
    {
        var response = await PostAsync(endpoint, body);
        return response.IsSuccessful 
            ? JsonConvert.DeserializeObject<T>(response.Content ?? "{}")
            : default(T);
    }
}