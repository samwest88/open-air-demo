using Dept.OpenAir.Services.Models.Cities;
using Dept.OpenAir.Services.Models.Measurements;

namespace Dept.OpenAir.Services
{
    public interface IApiClient
    {
        Task<GetCitiesResult> GetCities();
        Task<GetMeasurementsResult> GetMeasurements(string city);
    }
}
