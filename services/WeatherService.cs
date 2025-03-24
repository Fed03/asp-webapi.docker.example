using Microsoft.Extensions.Configuration;

namespace services;


public class WeatherService
{
    private readonly string? _lang;

    public WeatherService(IConfiguration config)
    {
        _lang = config["WeatherLanguage"];
    }
    
    private static readonly string[] EnSummaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];
    
    
    private static readonly string[] ItSummaries =
    [
        "Gelido", "Freddo", "MEdio", "Caldo", "Caldissimo", "Rovente"
    ];
    
    public IEnumerable<WeatherForecast> GetWeatherForecast(int daysNumber)
    {
        return Enumerable.Range(1, daysNumber).Select(
                index =>
                {
                    var summaries = _lang == "it" ? ItSummaries : EnSummaries;
                    return new WeatherForecast(
                        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        Random.Shared.Next(-20, 55),
                        summaries[Random.Shared.Next(summaries.Length)]
                    );
                }
            )
            .ToArray();
    }
}