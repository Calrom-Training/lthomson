FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Training.API.Core/Training.API.Core.csproj", "Training.API.Core/"]
COPY ["Training.API.DatabaseLibrary/Training.API.DatabaseLibrary.csproj", "Training.API.DatabaseLibrary/"]
RUN dotnet restore "Training.API.Core/Training.API.Core.csproj"
COPY . .
WORKDIR "/src/Training.API.Core"
RUN dotnet build "Training.API.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Training.API.Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Training.API.Core.dll"]