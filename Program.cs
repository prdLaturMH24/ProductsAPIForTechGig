using Microsoft.EntityFrameworkCore;
using ProductsAPIForTechGig.Data;
using ProductsAPIForTechGig.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (builder.Environment.IsProduction() || Environment.GetEnvironmentVariable("USE_SQLITE") == "true")
{
    // Use SQLite for production/container
    builder.Services.AddDbContext<ProductDbContext>(options =>
        options.UseSqlite(connectionString));
}
else
{
    // Use SQL Server for local development
    builder.Services.AddDbContext<ProductDbContext>(options =>
        options.UseSqlServer(connectionString));
}
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
    db.Database.EnsureCreated();
    db.Database.Migrate();
    SeedData.Initialize(scope.ServiceProvider);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
