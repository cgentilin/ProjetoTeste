using FluentValidation;
using Projeto.Teste.Cartao.Dominio.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Cartao.Aplicacao.Validacoes
{
    public class ConsultarPropostaComandoValidador : AbstractValidator<ConsultarPropostaComando>
    {
        public ConsultarPropostaComandoValidador()
        {
            RuleFor(a => a.DocumentoProponente)
               .NotEmpty()
               .Length(11)
               .WithMessage("Informe o CPF do proponente corretamente");
        }
    }
}
