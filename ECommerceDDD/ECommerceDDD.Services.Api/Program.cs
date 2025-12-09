using ECommerceDDD.Infra.IoC.DependencyInjection;
using ECommerceDDD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); ;

// pega a connection string do appsettings (ou da variável de ambiente)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// registra serviços de infraestrutura (DbContext, Repositories, UnitOfWork)
NativeInjectorBootStrapper.RegisterServices(builder.Services, connectionString);

// (opcional) registra controllers, swagger e demais serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.

builder.Services.AddControllers();
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
