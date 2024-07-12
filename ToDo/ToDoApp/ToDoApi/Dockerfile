FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5023

ENV ASPNETCORE_URLS=http://+:5023

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["ToDoApp/ToDoApi/ToDoApi.csproj", "ToDoApp/ToDoApi/"]
RUN dotnet restore "ToDoApp/ToDoApi/ToDoApi.csproj"
COPY . .
WORKDIR "/src/ToDoApp/ToDoApi"
RUN dotnet build "ToDoApi.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "ToDoApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoApi.dll"]
