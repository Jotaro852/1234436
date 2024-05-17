FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LABA2.3.csproj", "./"]
RUN dotnet restore "LABA2.3.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "LABA2.3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LABA2.3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LABA2.3.dll"]
