using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBContext;
using DBContext.Models2;

namespace EnergyApi.Controllers
{
    [Route("api/energyproduction")]
    [ApiController]
    public class EnergyProductionController : ControllerBase
    {
        private readonly EnergyContext _context;

        public EnergyProductionController(EnergyContext context)
        {
            _context = context;
        }
        
        // GET: api/energyproduction/smallhydro
        [HttpGet("smallhydro")]
        public async Task<IActionResult> GetSmallHydroData()
        {
            var smallHydros = await _context.SmallHydros
                .OrderBy(sh => sh.Year)
                .ToListAsync();

            // Convert Total from GWh to kWh
            foreach (var sh in smallHydros)
            {
                sh.Total = ConvertGWhToKWh(sh.Total);
            }

            return Ok(smallHydros);
        }
        

        // GET: api/energyproduction/wind
        [HttpGet("wind")]
        public async Task<IActionResult> GetWindData()
        {
            var winds = await _context.Winds
                .OrderBy(w => w.Year)
                .ToListAsync();

            // Convert Total from GWh to kWh (if needed)
            foreach (var w in winds)
            {
                w.Total = ConvertGWhToKWh(w.Total);
            }

            return Ok(winds);
        }

        // GET: api/energyproduction/biogas
        [HttpGet("biogas")]
        public async Task<IActionResult> GetBiogasData()
        {
            var biogases = await _context.Biogases
                .OrderBy(b => b.Year)
                .ToListAsync();

            // Convert Total from GWh to kWh (if needed)
            foreach (var b in biogases)
            {
                b.Total = ConvertGWhToKWh(b.Total);
            }

            return Ok(biogases);
        }

        // GET: api/energyproduction/photovoltaic
        [HttpGet("photovoltaic")]
        public async Task<IActionResult> GetPhotovoltaicData()
        {
            var photovoltaics = await _context.Photovoltaics
                .OrderBy(p => p.Year)
                .ToListAsync();

            // Convert Total from GWh to kWh (if needed)
            foreach (var p in photovoltaics)
            {
                p.Total = ConvertGWhToKWh(p.Total);
            }

            return Ok(photovoltaics);
        }

        // ConvertGWhToKWh
        private static decimal ConvertGWhToKWh(decimal totalInGWh)
        {
            return totalInGWh * 1_000_000; // Conversion logic from GWh to kWh
        }

        

    }
}
