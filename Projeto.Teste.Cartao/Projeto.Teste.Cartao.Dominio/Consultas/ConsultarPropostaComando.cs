using MediatR;
using Projeto.Teste.Cartao.Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Cartao.Dominio.Consultas
{
    /// <summary>
    /// Consulta por um ou mais dados informados no comando. O único obrigatório é o DocumentoProponente
    /// </summary>
    public class ConsultarPropostaComando : IRequest<Response>
    {
        public string DocumentoProponente { get; set; }
        public DateTime? DataProposta { get; set; }
        public decimal? ValorProposta { get; set; }
    }
}
