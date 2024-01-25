using LinqKit;
using MediatR;
using Microsoft.Extensions.Logging;
using Projeto.Teste.Cartao.Dominio.Consultas;
using Projeto.Teste.Cartao.Dominio.DTO;
using nscartao = Projeto.Teste.Cartao.Dominio.Entidades;
using Projeto.Teste.Cartao.Infraestrutura.Data.Repositorios;
using System.Net;

namespace Projeto.Teste.Cartao.Aplicacao.Handlers
{
    public class ConsultarCartaoHandler : IRequestHandler<ConsultarCartaoComando, Response>
    {
        private ICartaoRepositorio _repoProp;
        private ILogger<ConsultarCartaoHandler> _log;

        public ConsultarCartaoHandler(ICartaoRepositorio repoProp, ILogger<ConsultarCartaoHandler> log)
        {
            _repoProp = repoProp;
            _log = log;

        }
        public async Task<Response> Handle(ConsultarCartaoComando request, CancellationToken cancellationToken)
        {
            try
            {
                var query = Predicado(request);
                var clientes = await _repoProp.ObterCartaoAsync(query);

                var data = clientes
                           .Select(c => new ConsultarCartaoResposta(c))
                           .ToList()
                           .AsReadOnly();

                if (data?.Count() <= 0)
                {
                    return new Response(HttpStatusCode.NotFound)
                        .AddError($"Nenhuma proposta foi encontrara para o CPF {request.DocumentoTitular}");
                }

                return new Response(data);  //retorna lista de propostas se encontradas.

            }
            catch (Exception ex)
            {
                _log.LogError($"Erro ao consultar cartão CPF Titular {request.DocumentoTitular}" +
                    $"Exception {ex.Message}");

                return new Response(HttpStatusCode.InternalServerError).AddError("Erro ao consultar cartao");
            }

        }

        /// <summary>
        /// Criar uma query de consulta a partir de um ou mais campos do comando de entrada se informados.
        /// </summary>
        /// <param name="request">Documento é obrigatório, demais campos opcionais</param>
        /// <returns></returns>
        private ExpressionStarter<nscartao.Cartao> Predicado(ConsultarCartaoComando request)
        {
            //para adicionar mais campos a consulta verifique os indices da tabela
            //e o comando de entrada

            var predicado = PredicateBuilder.New<nscartao.Cartao>();

            if (!string.IsNullOrEmpty(request.DocumentoTitular))
                predicado.And(c => c.DocumentoTitular == request.DocumentoTitular);

            if (!string.IsNullOrEmpty(request.NumeroCartao))
                predicado.And(c => c.NumeroCartao == request.NumeroCartao);

            return predicado;
        }

    }
}
