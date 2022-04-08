using Dept.OpenAir.Api.Models;

namespace Dept.OpenAir.Api
{
    public interface IApiClient
    {
        Task<GetCitiesResult> GetCities();
    }
}
