using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBContext;
using DBContext.Models;
using InstallationAPI.Models;
using InstallationAPI.Converter;

namespace InstallationAPI.Controllers
{
    [Route("api/ElectricityProductionPlants")]
    [ApiController]
    public class ElectricityProductionPlantsController : ControllerBase
    {
        private readonly InstallationNeeContext _context;

        public ElectricityProductionPlantsController(InstallationNeeContext context)
        {
            _context = context;
        }

        // GET: api/ElectricityProductionPlants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElectricityProductionPlantM>>> GetElectricityProductionPlants()
        {
            //limit the number of installations to 1000
            var ListOfInstallations = await _context.ElectricityProductionPlants.Take(100)
                .ToListAsync();
            var mainCategory = await _context.MainCategoryCatalogues.ToListAsync();
            var subCategory = await _context.SubCategoryCatalogues.ToListAsync();
            var plantCategory = await _context.PlantCategoryCatalogues.ToListAsync();

            List<ElectricityProductionPlantM> ListOfInstallationsM = new List<ElectricityProductionPlantM>();
            foreach (var installation in ListOfInstallations)
            {
                ElectricityProductionPlantM installationM = new ElectricityProductionPlantM();
                installationM = installation.ToModel();
                installationM.MainCategory = mainCategory.Where(x => x.CatalogueId == installation.MainCategory).FirstOrDefault().De;
                installationM.SubCategory = subCategory.Where(x => x.CatalogueId == installation.SubCategory).FirstOrDefault().De;
                try
                {
                    installationM.PlantCategory = plantCategory.Where(x => x.CatalogueId == installation.PlantCategory).FirstOrDefault().De;
                }
                catch (Exception e)
                {
                    installationM.PlantCategory = "Unknown";
                }
                ListOfInstallationsM.Add(installationM);

            }


            return ListOfInstallationsM;

        }

    }
}
