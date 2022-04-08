using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dept.OpenAir.Web.Models.Pages
{
    public class HomeViewModel
    {
        public IEnumerable<SelectListItem> Cities { get; set; } = new List<SelectListItem>();
    }
}
