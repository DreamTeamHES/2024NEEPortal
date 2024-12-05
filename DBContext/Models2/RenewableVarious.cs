namespace DBContext.Models2
{
    public class RenewableVarious
    {
        public int Id { get; set; } // PK
        public double Total { get; set; }
        public int Year { get; set; }

        // Navigation property for sub-classes
        public List<Biogas> Biogases { get; set; }
        public List<Photovoltaic> Photovoltaics { get; set; }
        public List<Wind> Winds { get; set; }

        public RenewableVarious()
        {
            Biogases = new List<Biogas>();
            Photovoltaics = new List<Photovoltaic>();
            Winds = new List<Wind>();
        }
    }
}
