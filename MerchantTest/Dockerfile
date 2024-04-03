#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MerchantTest/MerchantTest.Api.csproj", "MerchantTest/"]
COPY ["Infrastructure/MerchantTest.Infrastructure.csproj", "Infrastructure/"]
COPY ["MerchantTest.Applicatiıon/MerchantTest.Applicatiıon.csproj", "MerchantTest.Applicatiıon/"]
COPY ["MerchantTest.Domain/MerchantTest.Domain.csproj", "MerchantTest.Domain/"]
RUN dotnet restore "./MerchantTest/./MerchantTest.Api.csproj"
COPY . .
WORKDIR "/src/MerchantTest"
RUN dotnet build "./MerchantTest.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MerchantTest.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MerchantTest.Api.dll"]