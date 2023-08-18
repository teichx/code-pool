#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CodePool.Location/CodePool.Location.csproj", "CodePool.Location/"]
RUN dotnet restore "CodePool.Location/CodePool.Location.csproj"
COPY . .
WORKDIR "/src/CodePool.Location"
RUN dotnet build "CodePool.Location.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
# Install clang/zlib1g-dev dependencies for publishing to native
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
    clang zlib1g-dev
RUN dotnet publish "CodePool.Location.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=true

FROM mcr.microsoft.com/dotnet/runtime-deps:8.0-preview AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
COPY --from=publish /app/publish .
ENTRYPOINT ["CodePool.Location"]
