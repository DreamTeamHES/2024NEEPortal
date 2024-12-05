using DBContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register InstallationNeeContext with its connection string
builder.Services.AddDbContext<InstallationNeeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        providerOptions => providerOptions.EnableRetryOnFailure()));

// Add CORS policy to allow requests from the Blazor app.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp",
        policy =>
        {
            policy.WithOrigins("https://addmap.azurewebsites.net") // Replace with your Blazor app's port
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});
// Register EnergyContext with its own connection string (EnergyConnection)
// This will use either the local or Azure connection depending on the appsettings.json configuration
builder.Services.AddDbContext<EnergyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EnergyConnection"),
        providerOptions => providerOptions.EnableRetryOnFailure()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Apply database migrations for both contexts
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // Migrate InstallationNeeContext
    // var installationContext = services.GetRequiredService<InstallationNeeContext>();
    // installationContext.Database.Migrate();

    // Migrate EnergyContext
    // var energyContext = services.GetRequiredService<EnergyContext>();
    // energyContext.Database.Migrate();
}

// Use CORS policy
app.UseCors("AllowBlazorApp");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
