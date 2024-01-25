using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Teste.Aplicacao.Handlers;

namespace Projeto.Teste.Aplicacao.IoC
{
    public static class AplicacaoIoC
    {
        public static void AddAplicacaoServicos(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICriarClienteHandler, CriarClienteHandler>();
            services.AddTransient<IConsultaClienteHandler, ConsultaClienteHandler>();
            services.AddTransient<IAtualizarClienteHandler, AtualizarClienteHandler>();
        }
    }
}
