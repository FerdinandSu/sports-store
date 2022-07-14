#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["municipal-length-converter/municipal-length-converter.csproj", "municipal-length-converter/"]
RUN dotnet restore "municipal-length-converter/municipal-length-converter.csproj"
COPY . .
WORKDIR "/src/municipal-length-converter"
RUN dotnet build "municipal-length-converter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "municipal-length-converter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "municipal-length-converter.dll"]