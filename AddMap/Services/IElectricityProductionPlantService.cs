using addMap.Models;

namespace addMap.Services
{
    public interface IElectricityProductionPlantService
    {
            Task<List<ElectricityProductionPlantM>> GetElectricityProductionPlantsAsync();
    }
}
