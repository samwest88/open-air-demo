using Dept.OpenAir.Api;
using Dept.OpenAir.Web.Models;
using Dept.OpenAir.Web.Models.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Dept.OpenAir.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiClient _apiClient;

        public HomeController(ILogger<HomeController> logger, IApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var citiesApiResult = (await _apiClient.GetCities()).Results;
            var citiesDropdown = citiesApiResult.Select(x => new SelectListItem { Text = x.City, Value = x.City });
            var model = new HomeViewModel { Cities = citiesDropdown };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// TODO: This came bolted into the initial template, can be removed. 
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }
    }
}