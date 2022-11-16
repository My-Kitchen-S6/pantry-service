FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["pantry-service.csproj", "./"]
RUN dotnet restore "pantry-service.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "pantry-service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "pantry-service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "pantry-service.dll"]
