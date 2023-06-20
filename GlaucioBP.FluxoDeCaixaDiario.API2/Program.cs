using AutoMapper;
using GlaucioBP.FluxoDeCaixaDiario.API2;
using GlaucioBP.FluxoDeCaixaDiario.Aplicacao.Interfaces;
using GlaucioBP.FluxoDeCaixaDiario.Aplicacao.Service;
using GlaucioBP.FluxoDeCaixaDiario.Dominio.Interfaces.Repositories;
using GlaucioBP.FluxoDeCaixaDiario.Infraestrutura.Data.DbContexts;
using GlaucioBP.FluxoDeCaixaDiario.Infraestrutura.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Dependency Injection

//AutoMapper

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Services
builder.Services.AddScoped<ILancamentoService, LancamentoService>();
builder.Services.AddScoped<ISaldoDiarioService, SaldoDiarioService>();

//Repository
builder.Services.AddDbContext<FluxoDeCaixaDiarioContexto>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<ILancamentoRepository, LancamentoRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


