#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["imperial-length-converter/imperial-length-converter.csproj", "imperial-length-converter/"]
RUN dotnet restore "imperial-length-converter/imperial-length-converter.csproj"
COPY . .
WORKDIR "/src/imperial-length-converter"
RUN dotnet build "imperial-length-converter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "imperial-length-converter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "imperial-length-converter.dll"]