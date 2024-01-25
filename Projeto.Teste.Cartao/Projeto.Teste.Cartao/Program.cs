using Projeto.Teste.Cartao.Configuracoes.Mediator;
using Projeto.Teste.Cartao.Infraestrutura.Data;
using Projeto.Teste.Cartao.Aplicacao.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddMediatorService(builder.Configuration);

builder.Services.AddAplicacaoServicos();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
