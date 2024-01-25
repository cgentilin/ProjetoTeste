using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Teste.Cartao.Aplicacao.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Cartao.Aplicacao.Ioc
{
    public static class AplicacaoIoC
    {
        public static void AddAplicacaoServicos(this IServiceCollection services)
        {
            services.AddHostedService<WorkerProposta>();
        }
    }
}
