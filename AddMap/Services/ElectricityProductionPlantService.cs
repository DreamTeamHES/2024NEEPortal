using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http.Json;
using addMap.Models;

namespace addMap.Services
{
    public class ElectricityProductionPlantService : IElectricityProductionPlantService
    {
        private readonly HttpClient _httpClient;

        public ElectricityProductionPlantService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ElectricityProductionPlantM>> GetElectricityProductionPlantsAsync()
        { 
            var response = await _httpClient.GetFromJsonAsync<List<ElectricityProductionPlantM>>("api/ElectricityProductionPlants");
            return response ?? new List<ElectricityProductionPlantM>();
        }
    }
}
