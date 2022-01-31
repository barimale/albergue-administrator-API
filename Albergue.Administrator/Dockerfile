#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["administrator/Albergue.Administrator/Albergue.Administrator.csproj", "administrator/Albergue.Administrator/"]
RUN dotnet restore "administrator/Albergue.Administrator/Albergue.Administrator.csproj"
COPY . .
WORKDIR "/src/administrator/Albergue.Administrator"
RUN dotnet build "Albergue.Administrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Albergue.Administrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Albergue.Administrator.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Albergue.Administrator.dll
