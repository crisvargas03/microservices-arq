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
COPY ["BookServices.API/BookServices.API.csproj", "BookServices.API/"]
COPY ["BookServices.BLL/BookServices.BLL.csproj", "BookServices.BLL/"]
COPY ["BooksServies.DAL/BooksServies.DAL.csproj", "BooksServies.DAL/"]
RUN dotnet restore "./BookServices.API/BookServices.API.csproj"
COPY . .
WORKDIR "/src/BookServices.API"
RUN dotnet build "./BookServices.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BookServices.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookServices.API.dll"]