using Projeto.Teste.Cartao.Dominio.Entidades;
using Projeto.Teste.Cartao.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Cartao.Dominio.Consultas
{
    public class ConsultarPropostaResposta
    {
        public long Id { get; set; }
        public string NomeProponente { get; set; }
        public string DocumentoProponente { get; set; }
        public DateTime DataProposta { get; set; }
        public decimal ValorProposta { get; set; }
        public decimal ValorRendaProponente { get; set; }
        public int SituacaoProposta { get; set; }

        public ConsultarPropostaResposta(Proposta prop)
        {
            this.Id = prop.Id;
            this.NomeProponente = prop.NomeProponente;
            this.DocumentoProponente = prop.DocumentoProponente;
            this.DataProposta = prop.DataProposta;
            this.ValorProposta = prop.ValorProposta;
            this.ValorRendaProponente = prop.ValorRendaProponente;
            this.SituacaoProposta = (int)prop.SituacaoProposta;
        }
    }
}
