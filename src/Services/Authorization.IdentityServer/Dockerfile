FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY /../../*.sln ./
WORKDIR /app/Services/Authorization.IdentityServer
RUN dotnet restore

# Copy everything else and build
WORKDIR /app
COPY ../../* ./
WORKDIR /app/Services/Authorization.IdentityServer
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app/Services/Authorization.IdentityServer
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "aspnetapp.dll"]