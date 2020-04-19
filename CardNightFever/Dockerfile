FROM codegold79/mvpstudio-dotnet:v1 as base
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CardNightFever.csproj", ""]
RUN dotnet restore "./CardNightFever.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CardNightFever.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CardNightFever.csproj" -c Release -o /app/publish

FROM base AS final
USER mvp
WORKDIR /home/mvp/app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "CardNightFever.dll"]