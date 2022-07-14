#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["skat-shoe-store/skat-shoe-store.csproj", "skat-shoe-store/"]
RUN dotnet restore "skat-shoe-store/skat-shoe-store.csproj"
COPY . .
WORKDIR "/src/skat-shoe-store"
RUN dotnet build "skat-shoe-store.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "skat-shoe-store.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "skat-shoe-store.dll"]