FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 5433

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Zavalinka.Api/.", "Zavalinka.Api/"]
COPY ["Zavalinka.BL/.", "Zavalinka.BL/"]
COPY ["Zavalinka.Common/.", "Zavalinka.Common/"]
COPY ["Zavalinka.DB/.", "Zavalinka.DB/"]
COPY ["Zavalinka.Domain/.", "Zavalinka.Domain/"]
#COPY nuget.config .
RUN dotnet restore "Zavalinka.Api/Zavalinka.Api.csproj"
COPY . .
WORKDIR "/src/Zavalinka.Api"
RUN dotnet build "Zavalinka.Api.csproj" -c Release -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Zavalinka.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zavalinka.Api.dll"]
