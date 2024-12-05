namespace DBContext.Models2
{
    public class Biogas
    {
        public int Id { get; set; } // PK
        public decimal Total { get; set; }
        public int Year { get; set; }
        public int RenewableVariousId { get; set; } // FK to RenewableVarious
        public RenewableVarious RenewableVarious { get; set; }
    }
}
