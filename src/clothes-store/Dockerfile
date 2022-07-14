#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["clothes-store/clothes-store.csproj", "clothes-store/"]
RUN dotnet restore "clothes-store/clothes-store.csproj"
COPY . .
WORKDIR "/src/clothes-store"
RUN dotnet build "clothes-store.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "clothes-store.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "clothes-store.dll"]