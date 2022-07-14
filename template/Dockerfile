#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["@@proj_name@@/@@proj_name@@.csproj", "@@proj_name@@/"]
RUN dotnet restore "@@proj_name@@/@@proj_name@@.csproj"
COPY . .
WORKDIR "/src/@@proj_name@@"
RUN dotnet build "@@proj_name@@.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "@@proj_name@@.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "@@proj_name@@.dll"]