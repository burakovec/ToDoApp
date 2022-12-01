#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Presentation/ToDoApp.Server/ToDoApp.Server.csproj", "Presentation/ToDoApp.Server/"]
COPY ["Presentation/ToDoApp.Client.Blazor/ToDoApp.Client.Blazor.csproj", "Presentation/ToDoApp.Client.Blazor/"]
COPY ["Domain/ToDoApp.Entity/ToDoApp.Entity.csproj", "Domain/ToDoApp.Entity/"]
COPY ["Infrastructure/ToDoApp.Repository/ToDoApp.Repository.csproj", "Infrastructure/ToDoApp.Repository/"]
COPY ["Infrastructure/ToDoApp.Identity/ToDoApp.Identity.csproj", "Infrastructure/ToDoApp.Identity/"]
COPY ["Domain/ToDoApp.Application/ToDoApp.Application.csproj", "Domain/ToDoApp.Application/"]
RUN dotnet restore "Presentation/ToDoApp.Server/ToDoApp.Server.csproj"
COPY . .
WORKDIR "/src/Presentation/ToDoApp.Server"
RUN dotnet build "ToDoApp.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDoApp.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoApp.Server.dll"]