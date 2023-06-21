# Imagem base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Imagem de compilação
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore "GlaucioBP.FluxoDeCaixaDiario.Aplicacao/GlaucioBP.FluxoDeCaixaDiario.Aplicacao.csproj"
RUN dotnet build "GlaucioBP.FluxoDeCaixaDiario.Aplicacao/GlaucioBP.FluxoDeCaixaDiario.Aplicacao.csproj" -c Release -o /app/build

RUN dotnet restore "GlaucioBP.FluxoDeCaixaDiario.Dominio/GlaucioBP.FluxoDeCaixaDiario.Dominio.csproj"
RUN dotnet build "GlaucioBP.FluxoDeCaixaDiario.Dominio/GlaucioBP.FluxoDeCaixaDiario.Dominio.csproj" -c Release -o /app/build

RUN dotnet restore "GlaucioBP.FluxoDeCaixaDiario.Infraestrutura.Data/GlaucioBP.FluxoDeCaixaDiario.Infraestrutura.Data.csproj"
RUN dotnet build "GlaucioBP.FluxoDeCaixaDiario.Infraestrutura.Data/GlaucioBP.FluxoDeCaixaDiario.Infraestrutura.Data.csproj" -c Release -o /app/build

RUN dotnet restore "GlaucioBP.FluxoDeCaixaDiario.Testes/GlaucioBP.FluxoDeCaixaDiario.Testes.csproj"
RUN dotnet build "GlaucioBP.FluxoDeCaixaDiario.Testes/GlaucioBP.FluxoDeCaixaDiario.Testes.csproj" -c Release -o /app/build

RUN dotnet restore "GlaucioBP.FluxoDeCaixaDiario.API2/GlaucioBP.FluxoDeCaixaDiario.API2.csproj"
RUN dotnet build "GlaucioBP.FluxoDeCaixaDiario.API2/GlaucioBP.FluxoDeCaixaDiario.API2.csproj" -c Release -o /app/build

# Publicação
FROM build AS publish
RUN dotnet publish "GlaucioBP.FluxoDeCaixaDiario.API2/GlaucioBP.FluxoDeCaixaDiario.API2.csproj" -c Release -o /app/publish

# Imagem final
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GlaucioBP.FluxoDeCaixaDiario.API2.dll"]

# Adicionar o diretório de ferramentas ao PATH
ENV PATH="${PATH}:/root/.dotnet/tools"