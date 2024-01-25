using LinqKit;
using MediatR;
using Microsoft.Extensions.Logging;
using Projeto.Teste.Cartao.Dominio.Consultas;
using Projeto.Teste.Cartao.Dominio.DTO;
using Projeto.Teste.Cartao.Dominio.Entidades;
using Projeto.Teste.Cartao.Infraestrutura.Data.Repositorios;
using System.Net;

namespace Projeto.Teste.Cartao.Aplicacao.Handlers
{
    public class ConsultarPropostaHandler : IRequestHandler<ConsultarPropostaComando, Response>
    {
        private IPropostaRepositorio _repoProp;
        private ILogger<ConsultarPropostaHandler> _log;

        public ConsultarPropostaHandler(IPropostaRepositorio repoProp, ILogger<ConsultarPropostaHandler> log)
        {
            _repoProp = repoProp;
            _log = log;
            
        }
        public async Task<Response> Handle(ConsultarPropostaComando request, CancellationToken cancellationToken)
        {
            try
            {
                var query = Predicado(request);
                var clientes = await _repoProp.ObterPropostaAsync(query);

                var data = clientes
                           .Select(c => new ConsultarPropostaResposta(c))
                           .ToList()
                           .AsReadOnly();

                if (data?.Count() <= 0)
                {
                    return new Response(HttpStatusCode.NotFound)
                        .AddError($"Nenhuma proposta foi encontrara para o CPF {request.DocumentoProponente}");
                }

                return new Response(data);  //retorna lista de propostas se encontradas.

            }catch(Exception ex) 
            {
                _log.LogError($"Erro ao consultar propostas proponente {request.DocumentoProponente}" +
                    $"Exceptio {ex.Message}");

                return new Response(HttpStatusCode.InternalServerError).AddError("Erro ao consultar a proposta");
            }

        }

        /// <summary>
        /// Criar uma query de consulta a partir de um ou mais campos do comando de entrada se informados.
        /// </summary>
        /// <param name="request">Documento é obrigatório, demais campos opcionais</param>
        /// <returns></returns>
        private ExpressionStarter<Proposta> Predicado(ConsultarPropostaComando request)
        {
            //para adicionar mais campos a consulta verifique os indices da tabela
            //e o comando de entrada

            var predicado = PredicateBuilder.New<Proposta>();

            if (!string.IsNullOrEmpty(request.DocumentoProponente))
                predicado.And(c => c.DocumentoProponente == request.DocumentoProponente);

            if (request.DataProposta.HasValue)
                predicado.And(c => c.DataProposta == request.DataProposta);

            if (request.ValorProposta.HasValue)
                predicado.And(c => c.ValorProposta == request.ValorProposta);

            return predicado;
        }

    }
}
