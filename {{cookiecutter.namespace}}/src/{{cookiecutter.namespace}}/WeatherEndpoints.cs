using System.Security.Cryptography;
using Microsoft.AspNetCore.Http.HttpResults;
using {{cookiecutter.namespace}}.Models;

namespace {{cookiecutter.namespace}};

public static class WeatherEndpoints
{
    public static void RegisterWeatherEndpoints(this WebApplication app)
    {
        var version = app.NewApiVersionSet("Weather").Build();

        var weatherGroup = app.MapGroup("/v{version:apiVersion}/weather");

        weatherGroup.MapGet("/", GetWeatherForecastAsync).WithName("GetWeatherForecast");

        weatherGroup.WithOpenApi().WithTags("Weather").WithApiVersionSet(version).HasApiVersion(1.0);
    }

    public static Task<Ok<WeatherForecast[]>> GetWeatherForecastAsync()
    {
        var summaries = new[]
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        };

        var forecast = Enumerable
            .Range(1, 5)
            .Select(
                index =>
                    new WeatherForecast(
                        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        RandomNumberGenerator.GetInt32(-20, 55),
                        summaries[RandomNumberGenerator.GetInt32(summaries.Length)]
                    )
            )
            .ToArray();
        return Task.FromResult(TypedResults.Ok(forecast));
    }
}
