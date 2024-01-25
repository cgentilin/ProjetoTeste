using Projeto.Teste.Cartao.Configuracoes.Mediator;
using Projeto.Teste.Cartao.Infraestrutura.Data;
using Projeto.Teste.Cartao.Aplicacao.Ioc;
using Projeto.Teste.Cartao.Configuracoes.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddMediatorService(builder.Configuration);
builder.Services.AddAplicacaoServicos();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
