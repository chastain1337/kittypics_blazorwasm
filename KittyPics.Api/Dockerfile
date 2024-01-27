FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["KittyPics.Api/KittyPics.Api.csproj", "KittyPics.Api/"]
COPY ["KittyPics.Shared/KittyPics.Shared.csproj", "KittyPics.Shared/"]
RUN dotnet restore "KittyPics.Api/KittyPics.Api.csproj"
COPY . .
WORKDIR "/src/KittyPics.Api"
RUN dotnet build "KittyPics.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "KittyPics.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KittyPics.Api.dll"]
