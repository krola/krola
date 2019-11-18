FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-stretch AS build
WORKDIR /src
COPY ["Services/Authorization.IdentityServer/Authorization.IdentityServer.csproj", "Services/Authorization.IdentityServer/"]
COPY ["Data/Authorization/Authorization (Data).csproj", "Data/Authorization/"]
COPY ["Core/Data/Data (Core).csproj", "Core/Data/"]
COPY ["Domain/Shared/Shared (Domain).csproj", "Domain/Shared/"]
COPY ["Domain/Authorization/Authorization (Domain).csproj", "Domain/Authorization/"]
RUN dotnet restore "Services/Authorization.IdentityServer/Authorization.IdentityServer.csproj"
COPY . .
WORKDIR "/src/Services/Authorization.IdentityServer"
RUN dotnet build "Authorization.IdentityServer.csproj" -r linux-arm -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Authorization.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Krola.Authorization.IdentityServer.dll"]