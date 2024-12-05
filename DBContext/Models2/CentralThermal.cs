namespace DBContext.Models2
{
    public class CentralThermal
    {
        public int Id { get; set; } // PK
        public double Total { get; set; }
        public int Year { get; set; }
        public int ThermalId { get; set; } // FK to Thermal
        public Thermal Thermal { get; set; }
    }
}
