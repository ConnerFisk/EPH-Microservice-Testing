FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
ENV HUSKY 0
COPY [".config", ".config"]
COPY ["src/{{cookiecutter.namespace}}/{{cookiecutter.namespace}}.csproj", "src/{{cookiecutter.namespace}}/"]
RUN dotnet tool restore
RUN dotnet restore "src/{{cookiecutter.namespace}}/{{cookiecutter.namespace}}.csproj"
COPY . .
WORKDIR "/src/src/{{cookiecutter.namespace}}"
RUN dotnet build "{{cookiecutter.namespace}}.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "{{cookiecutter.namespace}}.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "{{cookiecutter.namespace}}.dll"]
