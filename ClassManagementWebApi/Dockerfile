# filepath: /Users/mac/Desktop/projetos/ClassManagementWebApi/Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ClassManagementWebApi/ClassManagementWebApi.csproj", "ClassManagementWebApi/"]
RUN dotnet restore "ClassManagementWebApi/ClassManagementWebApi.csproj"
COPY . .
WORKDIR "/src/ClassManagementWebApi"
RUN dotnet build "ClassManagementWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ClassManagementWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClassManagementWebApi.dll"]