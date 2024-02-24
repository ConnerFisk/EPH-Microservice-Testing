using Asp.Versioning;
using {{cookiecutter.namespace}};
using {{cookiecutter.namespace}}.OpenApi;
using Microsoft.AspNetCore.Http.Json;
{%- if cookiecutter.include_db %}
using {{cookiecutter.namespace}}.Data;
using Microsoft.EntityFrameworkCore;
{%- endif %}
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;

Log.Logger = new LoggerConfiguration().WriteTo.Console(formatProvider: null).CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));

    builder.Services
        .AddApiVersioning(
            options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            }
        )
        .AddApiExplorer(
            options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            }
        );

    builder.Services.Configure<JsonOptions>(options =>
    {
        options.SerializerOptions.PropertyNamingPolicy = JsonSerializationDefaults.NamingPolicy;
    });

    builder.Services.ConfigureHttpJsonOptions(opts =>
    {
        opts.SerializerOptions.PropertyNamingPolicy = JsonSerializationDefaults.NamingPolicy;
    });

    builder.Services.AddTransient<ISerializerDataContractResolver>(
        (_) => new JsonSerializerDataContractResolver(JsonSerializationDefaults.Options)
    );
    {%- if cookiecutter.include_db %}

    builder.Services.AddDbContext<ApplicationDbContext>(
        options =>
        {
            options.UseLoggerFactory(LoggerFactory.Create(cfg => cfg.AddSerilog()));
            options
                .UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbConnection"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    );
    {%- endif %}
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SchemaFilter<ApiSchemaExamples>();
    });

    var app = builder.Build();

    app.UseSerilogRequestLogging();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    // register endpoints
    app.RegisterWeatherEndpoints();

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    await Log.CloseAndFlushAsync();
}
