FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /ToDoListAPI
RUN dotnet restore
RUN dotnet build -c Release -o /app/build
