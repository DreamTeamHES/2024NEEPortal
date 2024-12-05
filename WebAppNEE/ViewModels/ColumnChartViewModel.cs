using DBContext.Models2;
using System.Collections.Generic;

namespace WebAppNEE.ViewModels
{
    public class ColumnChartViewModel
    {
        public List<SmallHydro> SmallHydroData { get; set; }
        public List<Wind> WindData { get; set; }
        public List<Biogas> BiogasData { get; set; }
        public List<Photovoltaic> PhotovoltaicData { get; set; }
    }
}