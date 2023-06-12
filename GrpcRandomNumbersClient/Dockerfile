FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GrpcRandomNumbersClient.csproj", "GrpcRandomNumbersClient/"]
RUN dotnet restore "GrpcRandomNumbersClient/GrpcRandomNumbersClient.csproj"
WORKDIR "/src/GrpcRandomNumbersClient"
COPY . .
RUN dotnet build "GrpcRandomNumbersClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcRandomNumbersClient.csproj" -c Release -o /app/publish
    
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcRandomNumbersClient.dll"]
