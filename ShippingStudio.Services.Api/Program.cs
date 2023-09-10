using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ShippingStudio.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ShippingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShippingDbContext")));

// configure swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Shipping Studio Services API",
        Description = "This API provides the CORE functionality to the Shipping Studio Project",
        Contact = new OpenApiContact
        {
            Name = "Mohamed Ameerodien",

            Email = "ameerodien@outlook.com",
        },
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.Run();
