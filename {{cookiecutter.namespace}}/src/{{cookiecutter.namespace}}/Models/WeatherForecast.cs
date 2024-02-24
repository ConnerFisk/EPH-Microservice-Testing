namespace {{cookiecutter.namespace}}.Models;

public record WeatherForecast : IOpenApiExample<WeatherForecast>
{
    public WeatherForecast()
    { }

    public WeatherForecast(DateOnly date, int temperatureC, string? summary)
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }

    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public WeatherForecast ExampleData()
    {
        return new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Today),
            TemperatureC = -20,
            Summary = "Freezing",
        };
    }
}
