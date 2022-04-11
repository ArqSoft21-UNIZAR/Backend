FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
RUN useradd -M dotnetUser
WORKDIR /app

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-container

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["server.csproj", "./"]
RUN dotnet restore "server.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
USER dotnetUser
CMD dotnet server.dll --urls=http://+:$PORT
