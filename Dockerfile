# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "InnatAPP/InnatAPP.API/InnatAPP.API.csproj"
RUN dotnet publish "InnatAPP/InnatAPP.API/InnatAPP.API.csproj" -c Release -o /app/publish

# Estágio final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Heroku define a variável de ambiente PORT em runtime.
# Aqui você só precisa garantir que sua app use esse valor no código.
ENV ASPNETCORE_URLS=http://+:$PORT

# Exponha uma porta padrão só para o Docker não reclamar.
EXPOSE 8080

ENTRYPOINT ["dotnet", "InnatAPP.API.dll"]