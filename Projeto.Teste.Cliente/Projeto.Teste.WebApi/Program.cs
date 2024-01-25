using Projeto.Teste.Infraestrutura.Data;
using Projeto.Teste.Aplicacao.IoC;
using System.Reflection;
using Projeto.Teste.WebApi.Configuracoes.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwagger();

builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddAplicacaoServicos(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
