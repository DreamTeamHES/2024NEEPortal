using System;
using System.Collections.Generic;

namespace DBContext.Models;

public partial class MainCategoryCatalogue
{
    public string CatalogueId { get; set; } = null!;

    public string? De { get; set; }

    public string? Fr { get; set; }

    public string? It { get; set; }

    public string? En { get; set; }

    public virtual ICollection<ElectricityProductionPlant> ElectricityProductionPlants { get; set; } = new List<ElectricityProductionPlant>();
}
