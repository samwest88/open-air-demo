using Dept.OpenAir.Web.Models.Partials;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dept.OpenAir.Web.Models.Pages
{
    public class HomeViewModel
    {
        public string City { get; set; } = string.Empty;
        
        public IEnumerable<SelectListItem> Cities { get; set; } = Enumerable.Empty<SelectListItem>();

        public IEnumerable<MeasurementCardViewModel> Cards { get; set; } = Enumerable.Empty<MeasurementCardViewModel>();
    }
}
