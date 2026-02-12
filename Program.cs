using Microsoft.EntityFrameworkCore;
using ProductsAPIForTechGig.Data;
using ProductsAPIForTechGig.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Allow environment variable to override configuration (useful for Docker).
var envConnection = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
Console.Write("Environment ConnectionString:{0}", envConnection);
var connectionString = !string.IsNullOrWhiteSpace(envConnection)
    ? envConnection
    : builder.Configuration.GetConnectionString("DefaultConnection")
      ?? "Data Source=/app/data/Products.db";

connectionString = connectionString.Trim().Trim('"', '\'');

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();
try
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
    db.Database.Migrate();
    SeedData.Initialize(scope.ServiceProvider);
}
catch (Exception ex)
{
    Console.WriteLine($"Error while Migration: {ex.Message}");
    throw;
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // Only enable HTTPS redirection in Development where developer certificates
    // are available. In containerized Production builds the app is configured
    // to listen on plain HTTP (ASPNETCORE_URLS=http://+:5151) so redirecting
    // to HTTPS would break requests.
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
