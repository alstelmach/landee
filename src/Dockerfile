FROM mcr.microsoft.com/dotnet/sdk:7.0 AS sdk

WORKDIR /API
COPY ["API/Landee.Api/Landee.Api.csproj", "API/Landee.Api/"]

RUN dotnet restore "API/Landee.Api/Landee.Api.csproj" --runtime alpine-x64
COPY . .

RUN dotnet publish "API/Landee.Api/Landee.Api.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore \
    --runtime alpine-x64 \
    --self-contained true

FROM mcr.microsoft.com/dotnet/runtime-deps:7.0-alpine

RUN adduser \
    --disabled-password \
    --home /app \
    --gecos '' dotnetuser && chown -R dotnetuser /app

WORKDIR /app

COPY --from=sdk /app/publish .

EXPOSE 5017

USER dotnetuser

ENV ASPNETCORE_URLS http://*:5017
ENV ASPNETCORE_ENVIRONMENT Development

ENTRYPOINT ["./Landee.Api"]
