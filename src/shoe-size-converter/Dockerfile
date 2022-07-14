#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["shoe-size-converter/shoe-size-converter.csproj", "shoe-size-converter/"]
RUN dotnet restore "shoe-size-converter/shoe-size-converter.csproj"
COPY . .
WORKDIR "/src/shoe-size-converter"
RUN dotnet build "shoe-size-converter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "shoe-size-converter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "shoe-size-converter.dll"]