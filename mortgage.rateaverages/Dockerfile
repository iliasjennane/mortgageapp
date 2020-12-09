FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["mortgage.rateaverages.csproj", "./"]
RUN dotnet restore "mortgage.rateaverages.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "mortgage.rateaverages.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mortgage.rateaverages.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mortgage.rateaverages.dll"]
