FROM mcr.microsoft.com/dotnet/sdk:7.0
COPY . .
RUN dotnet restore ./ToDoListAPI.sln
RUN dotnet build ./ToDoListAPI.sln
