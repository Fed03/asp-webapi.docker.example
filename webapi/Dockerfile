FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /src

COPY ["webapi/webapi.csproj", "webapi/"]
RUN dotnet restore "webapi/webapi.csproj"

COPY . .

WORKDIR "/src/webapi"

RUN dotnet build "webapi.csproj" -c Release -o /app/build
RUN dotnet publish "webapi.csproj" -c Release -o /app/publish /p:UseAppHost=false

WORKDIR /app/publish
ENTRYPOINT ["dotnet", "webapi.dll"]
