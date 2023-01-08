#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ToDoListAPI.sln", "."]
COPY ["./ToDoListAPI/ToDoListAPI.csproj", "./ToDoListAPI/"]
COPY ["./ToDoListAPI.Tests/ToDoListAPI.Tests.csproj", "./ToDoListAPI.Tests/"]
RUN dotnet restore "./ToDoListAPI.sln"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ToDoListAPI.sln" -c Release -o /app/build

FROM build AS test
RUN dotnet test "ToDoListAPI.sln"

FROM build AS publish
RUN dotnet publish "ToDoListAPI.sln" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoListAPI.dll"]
