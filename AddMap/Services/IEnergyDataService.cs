using DBContext.Models2;

namespace addMap.Services
{
    public interface IEnergyDataService
    {
        Task<List<SmallHydro>> GetSmallHydroDataAsync();
        Task<List<Wind>> GetWindDataAsync();
        Task<List<Biogas>> GetBiogasDataAsync();
        Task<List<Photovoltaic>> GetPhotovoltaicDataAsync();
    }
}
