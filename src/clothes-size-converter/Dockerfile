#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["clothes-size-converter/clothes-size-converter.csproj", "clothes-size-converter/"]
RUN dotnet restore "clothes-size-converter/clothes-size-converter.csproj"
COPY . .
WORKDIR "/src/clothes-size-converter"
RUN dotnet build "clothes-size-converter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "clothes-size-converter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "clothes-size-converter.dll"]