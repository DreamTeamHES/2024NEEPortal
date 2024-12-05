using System.Net.Http.Json;
using DBContext.Models2;

namespace addMap.Services;

public class EnergyDataService : IEnergyDataService
{
    private readonly HttpClient _httpClient;

    public EnergyDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Method to fetch SmallHydro data from API
    public async Task<List<SmallHydro>> GetSmallHydroDataAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<SmallHydro>>("api/energyproduction/smallhydro");
    }

    // Method to fetch Wind data from API
    public async Task<List<Wind>> GetWindDataAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Wind>>("api/energyproduction/wind");
    }

    // Method to fetch Biogas data from API
    public async Task<List<Biogas>> GetBiogasDataAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Biogas>>("api/energyproduction/biogas");
    }

    // Method to fetch Photovoltaic data from API
    public async Task<List<Photovoltaic>> GetPhotovoltaicDataAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Photovoltaic>>("api/energyproduction/photovoltaic");
    }
}