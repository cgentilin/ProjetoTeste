using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Cartao.Dominio.Comandos
{
    public class InserirCartaoComando : IRequest<InserirCartaoResposta>
    {
        public string NumeroCartao { get; set; }
        public string DocumentoTitular { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataEmissao { get; set; }
        public int Situacao { get; set; }
    }
}
