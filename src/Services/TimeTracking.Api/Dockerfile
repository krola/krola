FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim-arm32v7 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster-arm32v7 AS build
WORKDIR /src
COPY ["Services/TimeTracking.Api/TimeTracking.Api.csproj", "Services/TimeTracking.Api/"]
COPY ["Data/TimeTracking/TimeTracking (Data).csproj", "Data/TimeTracking/"]
COPY ["Core/Data/Data (Core).csproj", "Core/Data/"]
COPY ["Core/Data/Infrastructure (Core).csproj", "Core/Infrastructure/"]
COPY ["Domain/Shared/Shared (Domain).csproj", "Domain/Shared/"]
COPY ["Domain/TimeTracking/TimeTracking (Domain).csproj", "Domain/TimeTracking/"]
RUN dotnet restore "Services/Authorization.IdentityServer/Authorization.IdentityServer.csproj"
COPY . .
WORKDIR "/src/Services/TimeTracking.Api"
RUN dotnet build "TimeTracking.Api.csproj" -r linux-arm -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TimeTracking.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Krola.TimeTracking.Api.dll"]