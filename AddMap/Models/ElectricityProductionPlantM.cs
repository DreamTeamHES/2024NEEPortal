namespace addMap.Models;

public class ElectricityProductionPlantM
{
    public int XtfId { get; set; }

    public string? Address { get; set; }

    public int? PostCode { get; set; }

    public string? Municipality { get; set; }

    public string? Canton { get; set; }

    public DateOnly? BeginningOfOperation { get; set; }

    public double? InitialPower { get; set; }

    public double? TotalPower { get; set; }

    public string? MainCategory { get; set; }

    public string? SubCategory { get; set; }

    public string? PlantCategory { get; set; }

    public double? X { get; set; }

    public double? Y { get; set; }
}
