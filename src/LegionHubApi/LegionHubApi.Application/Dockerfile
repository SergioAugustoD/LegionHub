FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5162

ENV ASPNETCORE_URLS=http://+:5162

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY . .
RUN dotnet restore "src/LegionHubApi/LegionHubApi.Application/LegionHubApi.Application.csproj"
COPY . .
WORKDIR "/src/src/LegionHubApi/LegionHubApi.Application"
RUN dotnet build "LegionHubApi.Application.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "LegionHubApi.Application.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LegionHubApi.Application.dll"]
