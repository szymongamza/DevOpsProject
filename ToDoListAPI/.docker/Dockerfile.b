FROM mcr.microsoft.com/dotnet/sdk:7.0
RUN git clone https://github.com/szymongamza/DevOpsJenkinsTry.git
WORKDIR /DevOpsJenkinsTry
RUN dotnet restore ./ToDoListAPI/ToDoListAPI.sln
RUN dotnet build ./ToDoListAPI/ToDoListAPI.sln
