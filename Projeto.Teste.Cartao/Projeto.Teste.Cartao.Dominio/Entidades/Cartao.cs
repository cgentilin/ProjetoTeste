using Projeto.Teste.Cartao.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Cartao.Dominio.Entidades
{
    public class Cartao
    {
        public long Id { get; set; }
        public string NumeroCartao { get; set; }
        public string DocumentoTitular { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataEmissao { get; set; }
        public enuSituacaoCartao Situacao { get; set; }

        /// <summary>
        /// Gera o cartão a partir de uma proposta se aprovada
        /// </summary>
        /// <param name="proposta">Proposta aprovada</param>
        public bool GerarCartao(Proposta proposta)
        {
            if (proposta.SituacaoProposta == enuSituacaoProposta.Aprovada)
            {
                DataEmissao = System.DateTime.Now;
                DataValidade = System.DateTime.Now.AddDays(365 * 2);  //vale por dois anos
                DocumentoTitular = proposta.DocumentoProponente;
                NumeroCartao = new Random().Next(10000, 99999).ToString();  //número qualquer
                Situacao = Dominio.Enum.enuSituacaoCartao.Ativo;
                return true;
            }
            return false;
        }
    }
}
