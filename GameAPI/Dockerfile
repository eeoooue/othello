
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src



COPY LibOthello/LibOthello.csproj LibOthello/
COPY OthelloGameAPI/OthelloGameAPI.csproj OthelloGameAPI/

RUN dotnet restore OthelloGameAPI/OthelloGameAPI.csproj

COPY . .

WORKDIR /src/OthelloGameAPI
RUN dotnet publish -c Release -o /out /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080 \
    ASPNETCORE_ENVIRONMENT=Production
EXPOSE 8080

COPY --from=build /out ./

ENTRYPOINT ["dotnet", "OthelloGameAPI.dll"]
