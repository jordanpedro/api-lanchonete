# Stage 1
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /build
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

# Stage 2
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS final
RUN apk add icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
WORKDIR /app

COPY --from=build /app .

ENV ASPNETCORE_URLS http://+:8001
EXPOSE 8001

ENTRYPOINT ["dotnet", "api-lanchonete.dll"]
