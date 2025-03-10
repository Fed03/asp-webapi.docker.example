using Microsoft.AspNetCore.Mvc;
using services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<WeatherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet(
        "/weatherforecast",
        ([FromServices] WeatherService service, [FromQuery] int numberOfDays = 5) =>
        {
            return service.GetWeatherForecast(numberOfDays);
        }
    )
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();