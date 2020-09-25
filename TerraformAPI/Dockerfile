#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TerraformAPI/TerraformAPI.csproj", "TerraformAPI/"]
RUN dotnet restore "TerraformAPI/TerraformAPI.csproj"
COPY . .
WORKDIR "/src/TerraformAPI"
RUN dotnet build "TerraformAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TerraformAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TerraformAPI.dll"]