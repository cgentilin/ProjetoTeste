using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Cartao.Dominio.Comandos
{
    public class InserirPropostaResposta
    {
        public long Id { get; set; }
        public string NomeProponente { get; set; }
        public string DocumentoProponente { get; set; }
        public DateTime DataProposta { get; set; }
        public decimal ValorProposta { get; set; }
        public decimal ValorRendaProponente { get; set; }
        public int SituacaoProposta { get; set; }
    }
}
