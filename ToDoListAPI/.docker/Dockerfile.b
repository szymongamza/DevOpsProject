FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /src
COPY ["ToDoListAPI.csproj", "."]
RUN dotnet restore "./ToDoListAPI.sln"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ToDoListAPI.sln" -c Release -o /app/build