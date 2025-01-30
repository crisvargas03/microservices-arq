# comands:
# docker build -t <nombre_image:tag> .
# docker run --name <nombre_para_contenedor> -p <puerto_host>:<puerto_contenedor> <nombre_imagen>

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CartServices.API/CartServices.API.csproj", "CartServices.API/"]
COPY ["CartServices.BLL/CartServices.BLL.csproj", "CartServices.BLL/"]
COPY ["CartServices.DAL/CartServices.DAL.csproj", "CartServices.DAL/"]
RUN dotnet restore "./CartServices.API/CartServices.API.csproj"
COPY . .
WORKDIR "/src/CartServices.API"
RUN dotnet build "./CartServices.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CartServices.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CartServices.API.dll"]