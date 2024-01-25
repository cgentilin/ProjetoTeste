using Projeto.Teste.Cartao.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Cartao.Dominio.Entidades
{
    /// <summary>
    /// Implementado um domínio rico com regras de negócio na classe domínio.
    /// </summary>
    public class Proposta
    {
        public long Id { get; set; }
        public string NomeProponente { get; set; }
        public string DocumentoProponente { get; set; }
        public DateTime DataProposta { get; set; }
        public decimal ValorProposta { get; set; }
        public decimal ValorRendaProponente { get; set; }
        public enuSituacaoProposta SituacaoProposta { get; set; }

        /// <summary>
        /// Regra negócio 1 - Valor mínimo da renda do proponente para solicitar cartão
        /// </summary>
        /// <returns></returns>
        public bool ValidaValorMinimoRenda()
        {
            return (ValorRendaProponente >= 900M);
        }

        /// <summary>
        /// Regra negócio 2 - Aprova proposta se Valor não for superior a 50% da renda do proponente 
        /// </summary>
        /// <returns></returns>
        public bool AnaliseProposta()
        {
            return ((ValorProposta / ValorRendaProponente) * 100) <= 50M;
        }
    }
}
