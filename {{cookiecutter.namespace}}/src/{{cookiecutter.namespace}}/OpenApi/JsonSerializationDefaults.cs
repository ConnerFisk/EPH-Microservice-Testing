using System.Text.Json;

namespace {{cookiecutter.namespace}}.OpenApi;

public static class JsonSerializationDefaults
{
    static JsonSerializationDefaults() => Options = new JsonSerializerOptions { PropertyNamingPolicy = NamingPolicy, };

    public static JsonSerializerOptions Options { get; set; }

    public static JsonNamingPolicy NamingPolicy { get; set; } = JsonNamingPolicy.SnakeCaseLower;
}
