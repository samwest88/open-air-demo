using Dept.OpenAir.Services.Models.Cities;
using Dept.OpenAir.Services.Models.Measurements;
using Dept.OpenAir.Web.Business.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Dept.OpenAir.Services
{
    /// <summary>
    /// Supports the following as per requirements: 
    /// 1. Retrieval of data for a city including sorting via a given field 
    /// 2. Appropriate logging
    /// 3. Injection
    /// TODO: Basic memory cache to fulfil the requirement of "storing" requests for future use
    ///     :https://docs.microsoft.com/en-us/aspnet/core/performance/caching/memory?view=aspnetcore-6.0
    /// </summary>
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiPrefix;
        private readonly ILogger<ApiClient> _logger;

        //TODO: This should probably be app-wide rather than specified here
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public ApiClient(IConfiguration config, ILogger<ApiClient> logger)
        {
            //TODO: Inject & consider factory: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-6.0
            _httpClient = new HttpClient();
            _apiPrefix = config.GetSection(ConfigurationConstants.ApiPrefix).Value;
            _jsonSerializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            _logger = logger;
        }

        public async Task<GetMeasurementsResult> GetMeasurements(string city)
        {
            var endpoint = "measurements";
            //TODO: Add these as parameter filters instead of hardcoded
            var query = $"date_from=2000-01-01T00%3A00%3A00%2B00%3A00&date_to=2022-04-11T13%3A43%3A00%2B00%3A00&limit=100&page=1&offset=0&sort=desc&radius=1000&city={city}&order_by=datetime";
            return await Get<GetMeasurementsResult>(endpoint, query);
        }

        public async Task<GetCitiesResult> GetCities()
        {
            var endpoint = "cities";
            //TODO: Add these as parameter filters instead of hardcoded
            var query = "limit=100&page=1&offset=0&sort=asc&order_by=city";
            return await Get<GetCitiesResult>(endpoint, query);
        }

        private async Task<T> Get<T>(string endpoint, string query) where T : new()
        {
            var url = $"{_apiPrefix}/{endpoint}?{query}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Error fetching from '{url}', " +
                    $"Response Code: {response.StatusCode} " +
                    $"Content: {content}");
            }
            var data = JsonSerializer.Deserialize<T>(content, _jsonSerializerOptions);
            if (data == null)
            {
                _logger.LogError($"Content: {content}");
                return new T();
            }
            return data;
        }
    }
}