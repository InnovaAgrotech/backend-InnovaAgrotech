FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia a solução e os projetos (ajustando os caminhos)
COPY ./InnatAPP/InnatAPP/*.sln ./InnatAPP/
COPY ./InnatAPP/InnatAPP/InnatAPP.API/*.csproj ./InnatAPP/InnatAPP/InnatAPP.API/
COPY ./InnatAPP/InnatAPP/InnatAPP.Application/*.csproj ./InnatAPP/InnatAPP/InnatAPP.Application/
COPY ./InnatAPP/InnatAPP/InnatAPP.Domain/*.csproj ./InnatAPP/InnatAPP/InnatAPP.Domain/
COPY ./InnatAPP/InnatAPP/InnatAPP.Infra.IoC/*.csproj ./InnatAPP/InnatAPP/InnatAPP.Infra.IoC/
COPY ./InnatAPP/InnatAPP/InnatAPP.Infra.Data/*.csproj ./InnatAPP/InnatAPP/InnatAPP.Infra.Data/

# Restaura as dependências
RUN dotnet restore "./InnatAPP/InnatAPP/InnatAPP.API/InnatAPP.API.csproj"

# Copia todo o código fonte
COPY ./InnatAPP/InnatAPP ./InnatAPP/InnatAPP

# Publica a API
WORKDIR /src/InnatAPP/InnatAPP/InnatAPP.API
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "InnatAPP.API.dll"]