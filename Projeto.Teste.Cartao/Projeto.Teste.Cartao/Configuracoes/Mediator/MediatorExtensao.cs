using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using Projeto.Teste.Cartao.Aplicacao.Validacoes;

namespace Projeto.Teste.Cartao.Configuracoes.Mediator
{
    public static class MediatorExtensao
    {
        public static void AddMediatorService(this IServiceCollection services, IConfiguration configuration)
        {
            const string applicationAssemblyName = "Projeto.Teste.Cartao.Aplicacao";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));

            services.AddMediatR(cfg =>
               cfg.RegisterServicesFromAssembly(assembly)
               .AddBehavior(typeof(IPipelineBehavior<,>),typeof(FailFastRequestBehavior<,>)));

        }
    }
}
