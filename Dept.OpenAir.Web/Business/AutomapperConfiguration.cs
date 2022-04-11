using AutoMapper;
using Dept.OpenAir.Api.Models;
using Dept.OpenAir.Web.Models.Partials;

namespace Dept.OpenAir.Web.Business
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            CreateMap<MeasurementResult, MeasurementCardViewModel>();
        }
    }
}
