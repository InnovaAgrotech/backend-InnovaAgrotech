FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia a solução e os projetos
COPY ../*.sln .
COPY ../InnatAPP.API/*.csproj ./InnatAPP.API/
COPY ../InnatAPP.Application/*.csproj ./InnatAPP.Application/
COPY ../InnatAPP.Domain/*.csproj ./InnatAPP.Domain/
COPY ../InnatAPP.Infra.IoC/*.csproj ./InnatAPP.Infra.IoC/
COPY ../InnatAPP.Infra.Data/*.csproj ./InnatAPP.Infra.Data/

# Restaura as dependências
RUN dotnet restore "./InnatAPP.API/InnatAPP.API.csproj"

# Copia todo o código fonte
COPY .. .

# Publica a API
WORKDIR /src/InnatAPP.API
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "InnatAPP.API.dll"]