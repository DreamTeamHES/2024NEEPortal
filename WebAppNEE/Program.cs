using WebAppNEE.Services;

var builder = WebApplication.CreateBuilder(args);

// adding a comment to show git (dev branch)
// adding another comment to show git (feature1 branch)

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IEnergyDataService, EnergyDataService>();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
