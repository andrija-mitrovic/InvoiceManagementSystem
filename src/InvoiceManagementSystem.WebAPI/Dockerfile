#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/InvoiceManagementSystem.WebAPI/InvoiceManagementSystem.WebAPI.csproj", "src/InvoiceManagementSystem.WebAPI/"]
COPY ["src/InvoiceManagementSystem.Application/InvoiceManagementSystem.Application.csproj", "src/InvoiceManagementSystem.Application/"]
COPY ["src/InvoiceManagementSystem.Domain/InvoiceManagementSystem.Domain.csproj", "src/InvoiceManagementSystem.Domain/"]
COPY ["src/InvoiceManagementSystem.Infrastructure/InvoiceManagementSystem.Infrastructure.csproj", "src/InvoiceManagementSystem.Infrastructure/"]
RUN dotnet restore "src/InvoiceManagementSystem.WebAPI/InvoiceManagementSystem.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/InvoiceManagementSystem.WebAPI"
RUN dotnet build "InvoiceManagementSystem.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InvoiceManagementSystem.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InvoiceManagementSystem.WebAPI.dll"]
