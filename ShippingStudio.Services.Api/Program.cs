using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ShippingStudio.Data;
using ShippingStudio.Data.Repository;
using ShippingStudio.Domain.Interfaces.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ShippingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShippingDbContext")));



#region Dependency Injection Registration
    builder.Services.AddTransient<ICurrency, CurrencyRepository>();

#endregion

// configure swashbuckle
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.UseSwagger();
app.UseSwaggerUI(c =>
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shipping Services API V1"));


app.Run();