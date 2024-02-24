using System.Text.Json;
using {{cookiecutter.namespace}}.Models;
using JetBrains.Annotations;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace {{cookiecutter.namespace}}.OpenApi;

[UsedImplicitly]
public class ApiSchemaExamples : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        // see if type implements IOpenApiExample... if so, use it to describe the example on the schema
        if (
            Array.Exists(
                context.Type.GetInterfaces(),
                x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IOpenApiExample<>)
            )
        )
        {
            var example = Activator.CreateInstance(context.Type) as IOpenApiExample<object>;
            schema.Example = new OpenApiString(
                JsonSerializer.Serialize(example?.ExampleData(), JsonSerializationDefaults.Options)
            );
        }
    }
}
