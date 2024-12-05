namespace DBContext.Models2
{
    public class CentralHydro
    {
        public int Id { get; set; } // PK
        public double Total { get; set; }
        public int Year { get; set; }
        public int HydroId { get; set; } // FK to Hydro
        public Hydro Hydro { get; set; }
    }
}
