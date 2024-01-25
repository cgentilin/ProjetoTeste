using MediatR;
using Microsoft.Extensions.Logging;
using Projeto.Teste.Cartao.Dominio.Comandos;
using Projeto.Teste.Cartao.Dominio.DTO;
using Projeto.Teste.Cartao.Dominio.Entidades;
using Projeto.Teste.Cartao.Dominio.Enum;
using Projeto.Teste.Cartao.Infraestrutura.Data.Repositorios;
using Projeto.Teste.Cartao.Infraestrutura.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Cartao.Aplicacao.Handlers
{
    public class InserirPropostaHandler : IRequestHandler<InserirPropostaComando, Response>
    {
        private IPropostaRepositorio _repoProp;
        private IUnitOfWork _uow;
        private ILogger<InserirPropostaHandler> _log;

        public InserirPropostaHandler(
            IPropostaRepositorio repoProp,
            IUnitOfWork uow,
            ILogger<InserirPropostaHandler> log)
        {
            _repoProp = repoProp;
            _uow = uow;
            _log = log;
        }
        public async Task<Response> Handle(InserirPropostaComando request, CancellationToken cancellationToken)
        {
            try
            {
                var proposta = new Proposta()
                {
                    NomeProponente = request.NomeProponente,
                    DocumentoProponente = request.DocumentoProponente,
                    DataProposta = System.DateTime.Now,
                    ValorProposta = request.ValorProposta,
                    ValorRendaProponente = request.ValorRendaProponente,
                    SituacaoProposta = enuSituacaoProposta.AguardandoAnalise,
                };

                //domínio rico aplica regra de negócio. A entrada já foi validada com o Behavior
                if (!(proposta.ValidaValorMinimoRenda()))
                {
                    return new Response(HttpStatusCode.BadRequest)
                        .AddError("Renda Insuficiente ou valor proposto compromente 50% ou mais da renda Proponente");
                }

                _uow.BeginTransaction();

                var propostaInserida = await _repoProp.CreateAsync(proposta);
                var result = await _uow.SaveChangesAsync();

                _uow.CommitTransaction();

                _log.LogInformation($"Proposta cadastrada com sucesso Porponente {request.NomeProponente} " +
                    $"Documento {request.DocumentoProponente} Valor {request.ValorProposta.ToString()}");

                return new Response(HttpStatusCode.Created, propostaInserida);
            }
            catch (Exception ex)
            {

                _log.LogError($"Erro ao cadastrar proposta Porponente {request.NomeProponente}" +
                    $"Documento {request.DocumentoProponente} Valor {request.ValorProposta.ToString()}" +
                    $"Exception {ex.Message}");
                
                _uow.RollbackTransaction();

                return new Response(HttpStatusCode.InternalServerError).AddError("Erro ao tentar cadastrar a proposta");
            }

        }
    }
}
