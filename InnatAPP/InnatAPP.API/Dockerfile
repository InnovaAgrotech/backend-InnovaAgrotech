FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia a solução e os projetos (relativos à raiz do repo)
COPY ./InnatAPP/*.sln ./InnatAPP/
COPY ./InnatAPP/InnatAPP.API/*.csproj ./InnatAPP/InnatAPP.API/
COPY ./InnatAPP/InnatAPP.Application/*.csproj ./InnatAPP/InnatAPP.Application/
COPY ./InnatAPP/InnatAPP.Domain/*.csproj ./InnatAPP/InnatAPP.Domain/
COPY ./InnatAPP/InnatAPP.Infra.IoC/*.csproj ./InnatAPP/InnatAPP.Infra.IoC/
COPY ./InnatAPP/InnatAPP.Infra.Data/*.csproj ./InnatAPP/InnatAPP.Infra.Data/

# Restaura as dependências
RUN dotnet restore "./InnatAPP/InnatAPP.API/InnatAPP.API.csproj"

# Copia todo o código fonte (relativo à raiz)
COPY ./InnatAPP ./InnatAPP

# Publica a API
WORKDIR /src/InnatAPP/InnatAPP.API
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "InnatAPP.API.dll"]