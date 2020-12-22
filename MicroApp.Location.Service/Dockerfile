#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MicroApp.Location.Service/MicroApp.Location.Service.csproj", "MicroApp.Location.Service/"]
RUN dotnet restore "MicroApp.Location.Service/MicroApp.Location.Service.csproj"
COPY . .
WORKDIR "/src/MicroApp.Location.Service"
RUN dotnet build "MicroApp.Location.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroApp.Location.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroApp.Location.Service.dll"]