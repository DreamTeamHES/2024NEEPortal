namespace DBContext.Models2
{
    public class SmallHydro
    {
        public int Id { get; set; } // PK
        public decimal Total { get; set; }
        public int Year { get; set; }
        public int HydroId { get; set; } // FK to Hydro
        public Hydro Hydro { get; set; }
    }
}