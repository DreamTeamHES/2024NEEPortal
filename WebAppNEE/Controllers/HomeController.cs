using DBContext.Models2;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppNEE.Services;
using WebAppNEE.ViewModels;

namespace WebAppNEE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEnergyDataService _energyDataService;

        public HomeController(ILogger<HomeController> logger, IEnergyDataService energyDataService)
        {
            _logger = logger;
            _energyDataService = energyDataService;
        }

        // Modify the Index method to be async
        public async Task<IActionResult> Index(
            bool showBiogas = true,
            bool showPhotovoltaic = true,
            bool showWind = true,
            bool showSmallHydro = false)
        {
            // Retrieve data based on toggling flags
            var windData = showWind ? await _energyDataService.GetWindDataAsync() : new List<Wind>();
            var biogasData = showBiogas ? await _energyDataService.GetBiogasDataAsync() : new List<Biogas>();
            var photovoltaicData = showPhotovoltaic ? await _energyDataService.GetPhotovoltaicDataAsync() : new List<Photovoltaic>();
            var smallHydroData = showSmallHydro ? await _energyDataService.GetSmallHydroDataAsync() : new List<SmallHydro>();

            // Gather all years from the active datasets
            var years = new HashSet<int>();

            if (showBiogas && biogasData.Any())
                years.UnionWith(biogasData.Select(d => d.Year));

            if (showPhotovoltaic && photovoltaicData.Any())
                years.UnionWith(photovoltaicData.Select(d => d.Year));

            if (showWind && windData.Any())
                years.UnionWith(windData.Select(d => d.Year));

            if (showSmallHydro && smallHydroData.Any())
                years.UnionWith(smallHydroData.Select(d => d.Year));

            var orderedYears = years.OrderBy(y => y).ToList();

            // Populate the LineChartViewModel
            var viewModel = new LineChartViewModel
            {
                ShowBiogas = showBiogas,
                ShowPhotovoltaic = showPhotovoltaic,
                ShowWind = showWind,
                ShowSmallHydro = showSmallHydro,
                WindData = windData,
                BiogasData = biogasData,
                PhotovoltaicData = photovoltaicData,
                SmallHydroData = smallHydroData,
                Years = orderedYears
            };

            // Pass the viewModel to the Index view
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
