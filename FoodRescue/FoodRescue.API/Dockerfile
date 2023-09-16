#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FoodRescue.API/FoodRescue.API.csproj", "FoodRescue.API/"]
COPY ["FoodRescue.Application/FoodRescue.Application.csproj", "FoodRescue.Application/"]
COPY ["FoodRescue.Domain/FoodRescue.Domain.csproj", "FoodRescue.Domain/"]
COPY ["FoodRescue.Infrastructure/FoodRescue.Infrastructure.csproj", "FoodRescue.Infrastructure/"]
RUN dotnet restore "FoodRescue.API/FoodRescue.API.csproj"
COPY . .
WORKDIR "/src/FoodRescue.API"
RUN dotnet build "FoodRescue.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FoodRescue.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FoodRescue.API.dll"]