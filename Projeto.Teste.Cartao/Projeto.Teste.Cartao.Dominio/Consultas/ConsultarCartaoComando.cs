using MediatR;
using Projeto.Teste.Cartao.Dominio.DTO;

namespace Projeto.Teste.Cartao.Dominio.Consultas
{
    public class ConsultarCartaoComando : IRequest<Response>
    {
        public string? NumeroCartao { get; set; }
        public string DocumentoTitular { get; set; }
    }
}
