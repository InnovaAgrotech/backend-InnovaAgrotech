# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia tudo de uma vez (menos eficiente, mas mais seguro)
COPY . .

# Restaura e publica apenas o projeto da API
RUN dotnet restore "InnatAPP/InnatAPP.API/InnatAPP.API.csproj"
RUN dotnet publish "InnatAPP/InnatAPP.API/InnatAPP.API.csproj" -c Release -o /app/publish

# Estágio final (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "InnatAPP.API.dll"]