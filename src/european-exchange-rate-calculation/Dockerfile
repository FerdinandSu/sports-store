#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["european-exchange-rate-calculation/european-exchange-rate-calculation.csproj", "european-exchange-rate-calculation/"]
RUN dotnet restore "european-exchange-rate-calculation/european-exchange-rate-calculation.csproj"
COPY . .
WORKDIR "/src/european-exchange-rate-calculation"
RUN dotnet build "european-exchange-rate-calculation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "european-exchange-rate-calculation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "european-exchange-rate-calculation.dll"]