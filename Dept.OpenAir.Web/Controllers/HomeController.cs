﻿using AutoMapper;
using Dept.OpenAir.Services;
using Dept.OpenAir.Web.Models;
using Dept.OpenAir.Web.Models.Pages;
using Dept.OpenAir.Web.Models.Partials;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Dept.OpenAir.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiClient _apiClient;
        private readonly IMapper _mapper;
        
        public HomeController(ILogger<HomeController> logger, IApiClient apiClient, IMapper mapper)
        {
            _logger = logger;
            _apiClient = apiClient;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //TODO: Can potentially use a list of cities for autocomplete, but too many of them for a dropdown like this
            //var citiesApiResult = (await _apiClient.GetCities()).Results;
            //var citiesDropdown = citiesApiResult.Select(x => new SelectListItem { Text = x.City, Value = x.City });
            //var model = new HomeViewModel { Cities = citiesDropdown };
            return View(new HomeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomeViewModel model)
        {
            var measurements = await _apiClient.GetMeasurements(model.City);
            var measurementCards = _mapper.Map<IEnumerable<MeasurementCardViewModel>>(measurements.Results);
            model.Cards = measurementCards;
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}