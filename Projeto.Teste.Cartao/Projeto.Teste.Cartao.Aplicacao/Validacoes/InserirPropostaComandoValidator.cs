using FluentValidation;
using Projeto.Teste.Cartao.Dominio.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Cartao.Aplicacao.Validacoes
{
    /// <summary>
    /// Valida entrada comando Inserir proposta. Regras de negócio serão validadas no domínio
    /// </summary>
    public class InserirPropostaComandoValidator : AbstractValidator<InserirPropostaComando>
    {
        public InserirPropostaComandoValidator()
        {
            RuleFor(a => a.NomeProponente)
               .NotEmpty()
               .WithMessage("Informe o nome do Proponente");

            RuleFor(a => a.DocumentoProponente)
               .NotEmpty()
               .WithMessage("CPF do Proponente é obrigatório");

            RuleFor(a => a.ValorRendaProponente)
               .NotEmpty()
               .GreaterThan(0)
               .WithMessage("Informe a Renda do Proponente");

            RuleFor(a => a.ValorProposta)
               .NotEmpty()
               .GreaterThan(0)
               .WithMessage("Informe o valor da Proposta");

            RuleFor(a => a.ValorRendaProponente)
               .GreaterThan(a=> a.ValorProposta)
               .WithMessage("Renda do Proponente não pode ser menor que o valor da proposta");
        }
    }
}
