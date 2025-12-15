using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace DevHabit.Api.Controllers;

[System.Diagnostics.CodeAnalysis.SuppressMessage(
    "Design",
    "CA1515:Types can be made internal",
    Justification = "ASP.NET Core controllers are part of the public HTTP API")]
[ApiController]
[Route("[controller]")]
public sealed class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild",
        "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static readonly Action<ILogger, Exception?> LogGeneratingForecast =
        LoggerMessage.Define(
            LogLevel.Information,
            new EventId(1, nameof(Get)),
            "Generating weather forecast data.");

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        LogGeneratingForecast(_logger, null);

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = RandomNumberGenerator.GetInt32(-20, 55),
            Summary = Summaries[RandomNumberGenerator.GetInt32(Summaries.Length)]
        });
    }
}
