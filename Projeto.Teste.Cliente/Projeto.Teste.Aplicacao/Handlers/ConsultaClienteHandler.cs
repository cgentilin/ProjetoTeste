using LinqKit;
using Microsoft.Extensions.Logging;
using Projeto.Teste.Dominio.Consultas.Request;
using Projeto.Teste.Dominio.Consultas.Response;
using Projeto.Teste.Dominio.DTO;
using Projeto.Teste.Dominio.Entidades;
using Projeto.Teste.Infraestrutura.Data.Repositorios;

namespace Projeto.Teste.Aplicacao.Handlers
{
    public class ConsultaClienteHandler : IConsultaClienteHandler
    {
        private IClienteRepositorio<Cliente> _repo;
        private ILogger<ConsultaClienteHandler> _log;

        public ConsultaClienteHandler(IClienteRepositorio<Cliente> repocliente, ILogger<ConsultaClienteHandler> log)
        {
            _repo = repocliente;
            _log = log;
        }
        public async Task<Resultado<IList<ConsultarClienteResponse>>> Handle(ConsultarClienteRequest request)
        {
            var query = Predicado(request);
            var clientes = await _repo.ObterClienteAsync(query);
            
            var data = clientes
                       .Select(c => new ConsultarClienteResponse(c))
                       .ToList()
                       .AsReadOnly();

            return new Resultado<IList<ConsultarClienteResponse>>(data, true, "Sucesso");
        }

        /// <summary>
        /// Retornar uma expressão que pode ser utilizada como query. Ex: no método Where do EntityFramerowk
        /// </summary>
        /// <param name="request">Comando contendo um ou mais valores pelos quais se deseja pesquisar o cliente na base</param>
        /// <returns></returns>
        private ExpressionStarter<Cliente> Predicado(ConsultarClienteRequest request)
        {
            //pesquisa feita apenas pelos campos indexados tabela

            var predicado = PredicateBuilder.New<Cliente>();  

            if (!string.IsNullOrEmpty(request.Email))
                predicado.And(c => c.Email == request.Email);

            if (!string.IsNullOrEmpty(request.Documento))
                predicado.And(c => c.Documento == request.Documento);

            if (request.Id.HasValue)
                predicado.And(c => c.Id == request.Id.Value);

            return predicado;
        }
    }
}
