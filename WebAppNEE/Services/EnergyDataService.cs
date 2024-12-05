using DBContext.Models2;

namespace WebAppNEE.Services;

public class EnergyDataService : IEnergyDataService
{
    private readonly HttpClient _httpClient;

    public EnergyDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://installationapi2024.azurewebsites.net/");
    }

    // Method to fetch SmallHydroM data from API
    public async Task<List<SmallHydro>> GetSmallHydroDataAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<SmallHydro>>("api/energyproduction/smallhydro");
    }

    // Method to fetch WindM data from API
    public async Task<List<Wind>> GetWindDataAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Wind>>("api/energyproduction/wind");
    }

    // Method to fetch BiogasM data from API
    public async Task<List<Biogas>> GetBiogasDataAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Biogas>>("api/energyproduction/biogas");
    }

    // Method to fetch PhotovoltaicM data from API
    public async Task<List<Photovoltaic>> GetPhotovoltaicDataAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Photovoltaic>>("api/energyproduction/photovoltaic");
    }
}