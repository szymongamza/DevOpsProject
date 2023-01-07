FROM mcr.microsoft.com/dotnet/sdk:7.0
RUN ls
RUN dotnet restore ../ToDoListAPI.sln
RUN dotnet build ../ToDoListAPI.sln -c Release -o /app/build
