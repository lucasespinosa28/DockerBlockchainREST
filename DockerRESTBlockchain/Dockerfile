#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["DockerRESTBlockchain/DockerRESTBlockchain.csproj", "DockerRESTBlockchain/"]
RUN dotnet restore "DockerRESTBlockchain/DockerRESTBlockchain.csproj"
COPY . .
WORKDIR "/src/DockerRESTBlockchain"
RUN dotnet build "DockerRESTBlockchain.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerRESTBlockchain.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:443;http://+:80
ENTRYPOINT ["dotnet", "DockerRESTBlockchain.dll"]