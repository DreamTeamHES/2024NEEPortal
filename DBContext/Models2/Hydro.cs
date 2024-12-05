namespace DBContext.Models2
{
    public class Hydro
    {
        public int Id { get; set; } // PK: Primary Key
        public double Total { get; set; }
        public int Year { get; set; }

        // Navigation property for sub-classes
        public List<CentralHydro> CentralHydros { get; set; }
        public List<SmallHydro> SmallHydros { get; set; }

        public Hydro()
        {
            CentralHydros = new List<CentralHydro>();
            SmallHydros = new List<SmallHydro>();
        }
    }
}
