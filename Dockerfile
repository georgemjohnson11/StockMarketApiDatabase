FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine AS builder
LABEL maintainer="georgemjohnson11"
WORKDIR /app

# Copy solution and restore as distinct layers to cache dependencies
COPY ./Stocks.Domain/*.csproj ./Stocks.Domain/
COPY ./Stocks.Data/*.csproj ./Stocks.Data/
COPY *.sln ./
RUN dotnet restore

# Publish the application
COPY . ./
WORKDIR /app
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine AS runtime
WORKDIR /app
COPY --from=builder /app/Stocks.Domain/out .
ENTRYPOINT ["dotnet", "Stocks.Domain.dll"]
