using DBContext.Models2;
using Microsoft.AspNetCore.Mvc;
using WebAppNEE.Services;
using WebAppNEE.ViewModels;

namespace WebAppNEE.Controllers
{
    public class EnergyController : Controller
    {
        private readonly ILogger<EnergyController> _logger;
        private readonly IEnergyDataService _energyDataService;

        public EnergyController(ILogger<EnergyController> logger, IEnergyDataService energyDataService)
        {
            _logger = logger;
            _energyDataService = energyDataService;
        }

        // Get all energy data from 2017 and 2018
        public async Task<IActionResult> Index()
        {
            var smallHydroData = await _energyDataService.GetSmallHydroDataAsync();
            var windData = await _energyDataService.GetWindDataAsync();
            var biogasData = await _energyDataService.GetBiogasDataAsync();
            var photovoltaicData = await _energyDataService.GetPhotovoltaicDataAsync();

            var viewModel = new ColumnChartViewModel
            {
                SmallHydroData = smallHydroData,
                WindData = windData,
                BiogasData = biogasData,
                PhotovoltaicData = photovoltaicData
            };

            return View("ColumnView", viewModel);
        }

        // Action method for Biogas view
        public IActionResult Biogas()
        {
            return View(); // This will render the Biogas.cshtml view
        }

        // Action method for Small Hydro view
        public IActionResult SmallHydro()
        {
            return View(); // This will render the SmallHydro.cshtml view
        }

        // Action method for Solar Panel view
        public IActionResult SolarPannel()
        {
            return View(); // This will render the SolarPanel.cshtml view
        }

        // Action method for Wind Mill view
        public IActionResult WindMill()
        {
            return View(); // This will render the WindMill.cshtml view
        }


    }

    
}
