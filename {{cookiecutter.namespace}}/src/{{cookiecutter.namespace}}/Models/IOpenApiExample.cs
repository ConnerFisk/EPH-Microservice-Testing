namespace {{cookiecutter.namespace}}.Models;

/// <summary>
/// Construct an example of the implementing type for the OpenAPI schema.
/// </summary>
/// <typeparam name="T">The type of the model that is being described.</typeparam>
public interface IOpenApiExample<out T>
{
    T ExampleData();
}
