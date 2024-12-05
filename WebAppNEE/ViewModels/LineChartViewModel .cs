using DBContext.Models2;

namespace WebAppNEE.ViewModels
{
    public class LineChartViewModel
    {
        public bool ShowBiogas { get; set; }
        public bool ShowPhotovoltaic { get; set; }
        public bool ShowWind { get; set; }
        public bool ShowSmallHydro { get; set; }

        public List<Wind> WindData { get; set; }
        public List<Biogas> BiogasData { get; set; }
        public List<Photovoltaic> PhotovoltaicData { get; set; }
        public List<SmallHydro> SmallHydroData { get; set; }

        public List<int> Years { get; set; }
    }

}