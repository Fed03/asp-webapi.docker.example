FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS copy
WORKDIR /src
COPY WebApplication1.csproj .
RUN dotnet restore WebApplication1.csproj
COPY . .

FROM copy AS build
ARG BUILD_CONFIGURATION=Release
RUN dotnet build "WebApplication1.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM copy AS dev
ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV DOTNET_WATCH_SUPPRESS_LAUNCH_BROWSER=1
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_URLS=http://0.0.0.0:5024
ENTRYPOINT ["dotnet", "watch", "run", "--project", "WebApplication1.csproj", "--no-launch-profile", "http"]

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WebApplication1.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final

EXPOSE 8080
EXPOSE 8081

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
