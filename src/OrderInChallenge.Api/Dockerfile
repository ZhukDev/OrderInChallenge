#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN apt-get update -yq && apt-get upgrade -yq && apt-get install -yq curl git nano
RUN curl -sL https://deb.nodesource.com/setup_10.x | bash - && apt-get install -yq nodejs build-essential

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/OrderInChallenge.Api/OrderInChallenge.Api.csproj", "src/OrderInChallenge.Api/"]
COPY ["src/OrderInChallenge.Commands/OrderInChallenge.Commands.csproj", "src/OrderInChallenge.Commands/"]
COPY ["src/OrderInChallenge.Queries/OrderInChallenge.Queries.csproj", "src/OrderInChallenge.Queries/"]
COPY ["src/OrderInChallenge.DataAccess/OrderInChallenge.DataAccess.csproj", "src/OrderInChallenge.DataAccess/"]
RUN dotnet restore "src/OrderInChallenge.Api/OrderInChallenge.Api.csproj"
COPY . .
WORKDIR "/src/src/OrderInChallenge.Api"
RUN dotnet build "OrderInChallenge.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderInChallenge.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderInChallenge.Api.dll"]