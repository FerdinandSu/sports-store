#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ski-board-store/ski-board-store.csproj", "ski-board-store/"]
RUN dotnet restore "ski-board-store/ski-board-store.csproj"
COPY . .
WORKDIR "/src/ski-board-store"
RUN dotnet build "ski-board-store.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ski-board-store.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ski-board-store.dll"]