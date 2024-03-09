FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/MateMachine.LiveCoding.BackEnd.Console/MateMachine.LiveCoding.BackEnd.Console.csproj", "src/MateMachine.LiveCoding.BackEnd.Console/"]
RUN dotnet restore "src/MateMachine.LiveCoding.BackEnd.Console/MateMachine.LiveCoding.BackEnd.Console.csproj"
COPY . .
WORKDIR "/src/src/MateMachine.LiveCoding.BackEnd.Console"
RUN dotnet build "MateMachine.LiveCoding.BackEnd.Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MateMachine.LiveCoding.BackEnd.Console.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MateMachine.LiveCoding.BackEnd.Console.dll"]
