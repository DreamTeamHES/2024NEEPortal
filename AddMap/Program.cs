using addMap;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://installationapi2024.azurewebsites.net/") });

builder.Services.AddScoped<addMap.Services.ElectricityProductionPlantService>();
builder.Services.AddScoped<addMap.Services.EnergyDataService>();

builder.Services.AddBlazorBootstrap();

await builder.Build().RunAsync();
