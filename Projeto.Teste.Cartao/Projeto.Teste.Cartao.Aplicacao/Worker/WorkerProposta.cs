using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Projeto.Teste.Cartao.Infraestrutura.Data.Repositorios;
using Projeto.Teste.Cartao.Infraestrutura.Data.UnitOfWork;
using nscartao = Projeto.Teste.Cartao.Dominio.Entidades;

namespace Projeto.Teste.Cartao.Aplicacao.Worker
{
    /// <summary>
    /// Worker Processa Propostas.
    /// </summary>
    public class WorkerProposta : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<WorkerProposta> _log;
        private readonly IConfiguration _config;
        private readonly int _miliSegundos;

        public WorkerProposta(IServiceScopeFactory serviceScopeFactory, 
            ILogger<WorkerProposta> log,
            IConfiguration config)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _log = log;
            _config = config;
            _miliSegundos = 1000 * Convert.ToInt32(_config.GetSection("WorkerPropostaConfig:SegundosExecucao").Value ?? "60");
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _log.LogInformation($"Iniciando Worker {System.DateTime.Now}");

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.WhenAll(AnalisarProposta(), Task.Delay(_miliSegundos, stoppingToken)).ConfigureAwait(false);
            }
            _log.LogInformation($"Finalizando Worker {System.DateTime.Now}");
        }

        /// <summary>
        /// Processo Aprova ou Reprova propostas.
        /// </summary>
        /// <returns></returns>
        private async Task AnalisarProposta()
        {
            using (var scopo = _serviceScopeFactory.CreateScope())
            {
                var repoProposta = scopo.ServiceProvider.GetRequiredService<IPropostaRepositorio>();
                var repoCartao = scopo.ServiceProvider.GetRequiredService<ICartaoRepositorio>();
                var uow = scopo.ServiceProvider.GetRequiredService<IUnitOfWork>();

                var propostas = await repoProposta.
                    GetByQuery(p => p.SituacaoProposta == Dominio.Enum.enuSituacaoProposta.AguardandoAnalise).
                    Take(10).
                    AsNoTracking().
                    ToListAsync();

                try
                {
                    if (propostas.Count > 0)
                        uow.BeginTransaction();
                    else
                        _log.LogInformation($"Worker não existem propostas na fila. Proxyma execução" + 
                            $"em {System.DateTime.Now.ToLocalTime().AddMilliseconds(_miliSegundos)}");

                    foreach (var proposta in propostas)
                    {
                        _log.LogInformation($"Worker processando proposta {proposta.Id} " +
                            $"Proponente {proposta.DocumentoProponente}");

                        if (proposta.AnaliseProposta())
                        {
                            proposta.SituacaoProposta = Dominio.Enum.enuSituacaoProposta.Aprovada;
                            var cartao = new nscartao.Cartao();
                            if (cartao.GerarCartao(proposta))
                                repoCartao.Update(cartao);

                            _log.LogInformation($"Worker proposta {proposta.Id} Proponente " + 
                                $"{proposta.DocumentoProponente} Aprovada!");
                        }
                        else
                        {
                            proposta.SituacaoProposta = Dominio.Enum.enuSituacaoProposta.Reprovada;
                            _log.LogInformation($"Worker proposta {proposta.Id} Proponente " + 
                                $"{proposta.DocumentoProponente} Reprovada!");
                        }

                        repoProposta.Update(proposta);
                    }
                    await uow.SaveChangesAsync();
                    uow.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _log.LogError($"Worker Falna ao Processar propostas {ex.Message}");
                    uow.RollbackTransaction();
                }

            }
        }
    }
}
