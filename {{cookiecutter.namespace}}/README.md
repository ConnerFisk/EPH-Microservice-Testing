# {{cookiecutter.name}}

{{cookiecutter.description}}

## What does this app come configured with?

- ASPNET Core 8.0 Minimal API
- .NET 8.0 Unit Test Library
- .NET 8.0 Integration Test Library

### Additional packages configured

{%- if cookiecutter.include_db %}
- EF Core v8.0
{%- endif %}
- StyleCop - Code analysis
- FxCop - analysis
- Serilog - logging platform
- NSubstitute - .NET mocking library for tests
- Shouldly - Assertion library for tests

## Requirements

- Rider or VS2022 or similar
{%- if cookiecutter.include_db %}
- SQL Server (Docker or local install is fine)
{%- endif %}

