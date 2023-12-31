using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ShippingStudio.Data;
using ShippingStudio.Data.Repository;
using ShippingStudio.Domain.Interfaces.Repository;
using ShippingStudio.Services.Api.Interfaces;
using ShippingStudio.Services.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ShippingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShippingDbContext")));

#region Dependency Injection Registration - Repositories
    builder.Services.AddTransient<ICurrency, CurrencyRepository>();
    builder.Services.AddTransient<IShippingPortRepository, ShippingPortRepository>();
    builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();   
    builder.Services.AddTransient<IFilingRepository, FilingRepository>();   
#endregion

// configure swashbuckle
builder.Services.AddSwaggerGen();

#region Dependency Injection Registration - Services
builder.Services.AddTransient<CurrencyService>();
builder.Services.AddTransient<ShippingPortService>();
builder.Services.AddTransient<SupplierService>();
builder.Services.AddTransient<IFilingService, FilingService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c =>
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shipping Services API V1"));


app.Run();
