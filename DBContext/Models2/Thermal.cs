namespace DBContext.Models2
{
    public class Thermal
    {
        public int Id { get; set; } // PK
        public double Total { get; set; }
        public int Year { get; set; }

        // Navigation property for sub-classes
        public List<CentralThermal> CentralThermals { get; set; }
        public List<RenewableThermal> RenewableThermals { get; set; }

        public Thermal()
        {
            CentralThermals = new List<CentralThermal>();
            RenewableThermals = new List<RenewableThermal>();
        }
    }
}
