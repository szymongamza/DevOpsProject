FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /DevOpsJenkinsTry/ToDoListAPI
RUN dotnet restore
RUN dotnet build -c Release -o /app/build
