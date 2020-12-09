FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["mortgageui.csproj", "./"]
RUN dotnet restore "mortgageui.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "mortgageui.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mortgageui.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV APPINSIGHTS_INSTRUMENTATIONKEY="4e6583af-62e3-4d0b-aadb-2b37e33ae30a"
ENTRYPOINT ["dotnet", "mortgageui.dll"]
