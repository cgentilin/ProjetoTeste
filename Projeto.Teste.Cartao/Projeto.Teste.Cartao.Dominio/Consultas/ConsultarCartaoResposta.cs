using Projeto.Teste.Cartao.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nscartao = Projeto.Teste.Cartao.Dominio.Entidades;

namespace Projeto.Teste.Cartao.Dominio.Consultas
{
    public class ConsultarCartaoResposta
    {
        public long Id { get; set; }
        public string NumeroCartao { get; set; }
        public string DocumentoTitular { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataEmissao { get; set; }
        public enuSituacaoCartao Situacao { get; set; }

        public ConsultarCartaoResposta(nscartao.Cartao cartao)
        {
            Id = cartao.Id;
            NumeroCartao = cartao.NumeroCartao;
            DocumentoTitular = cartao.DocumentoTitular;
            DataValidade = cartao.DataValidade;
            DataEmissao = cartao.DataEmissao;
            Situacao = cartao.Situacao;
        }
    }
}
