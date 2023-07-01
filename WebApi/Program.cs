
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi;
using Application.Interfaces;
using Application;
using WebApi.Controllers;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var connstr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddMvc().AddControllersAsServices();
builder.Services.AddScoped<CalculatorController>();
builder.Services.AddSingleton<PriceCalculatorFactory>();
builder.Services.AddTransient<ICalculatePrice, PriceCalculator>();
builder.Services.AddScoped<List<ICalculatePrice>>(serviceProvider =>
{
    var factory = new PriceCalculatorFactory();

    return new List<ICalculatePrice>
    {
        factory.CreateMileageCalculator(),
        factory.CreateColourCalculator(),
        factory.CreateGradeCalculator(),
        factory.CreateAgeCalculator()
    };
});



builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();