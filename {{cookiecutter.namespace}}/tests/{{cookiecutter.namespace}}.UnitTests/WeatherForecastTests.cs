using {{cookiecutter.namespace}};
using Shouldly;
using Xunit;

namespace {{cookiecutter.namespace}}.UnitTests;

public class WeatherForecastTests
{
    [Fact]
    public async Task Can_pull_weather()
    {
        var weather = await WeatherEndpoints.GetWeatherForecastAsync();
        weather.StatusCode.ShouldBe(200);
        weather.Value.ShouldNotBeNull();
        weather.Value.Length.ShouldBeGreaterThan(0);
    }
}
