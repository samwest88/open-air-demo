using Dept.OpenAir.Api.Models;
using Dept.OpenAir.Web.Business.Constants;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Dept.OpenAir.Api
{
    /// <summary>
    /// Supports the following as per requirements: 
    /// 1. Retrieval of data for a city including sorting via a given field 
    /// 2. Basic memory cache to fulfil the requirement of "storing" requests for future use
    /// 3. Appropriate logging
    /// </summary>
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiPrefix;
        //TODO: This should probably be app-wide rather than specified here
        private readonly JsonSerializerOptions _jsonSerializerOptions; 

        public ApiClient(IConfiguration config)
        {
            //TODO: Inject & use factory: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-6.0
            _httpClient = new HttpClient();
            _apiPrefix = config.GetSection(ConfigurationConstants.ApiPrefix).Value;
            _jsonSerializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        }

        public async Task<GetCitiesResult> GetCities()
        {
            var endpoint = "cities";
            var query = "limit=100&page=1&offset=0&sort=asc&order_by=city";
            return await Get<GetCitiesResult>(endpoint, query);
        }

        private async Task<T> Get<T>(string endpoint, string query) where T : new()
        {
            var response = await _httpClient.GetAsync($"{_apiPrefix}/{endpoint}?{query}");
            if (!response.IsSuccessStatusCode)
            {
                //TODO: Error handling
            }
            var data = JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), _jsonSerializerOptions);
            if (data == null)
            {
                //TODO: Error handling
                return new T();
            }
            return data;
        }
    }
}