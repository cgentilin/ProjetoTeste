using Krafted.Guards;
using Projeto.Teste.Dominio.Comandos;
using System.Reflection;
using opt = System.Text.RegularExpressions.RegexOptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Projeto.Teste.Dominio.Entidades
{
    public class Cliente
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string? RG { get; set; }
        public string Documento { get; set; }
        public string? Fone { get; set; }
        public DateTime? DataNascimento { get; set; }

        public bool Validar()
        {
            //guard clauses to know more só da uma olhada here ;)  https://maiconheck.io/krafted/articles/guards.html
            Guard.Against
                .NullOrWhiteSpace(Nome, "Não pode ser nulo ou branco", nameof(Nome))
                .NullOrWhiteSpace(Email, "Não pode ser nulo ou branco", nameof(Email))
                .NotMatch(Documento, @"^\d{11}$", opt.CultureInvariant, "Informar CPF 11 dígitos somente números");

            return true;
        }

        /// <summary>
        /// Atualiza uma ou mais propriedades(que possam ser escritas) da entidade cliente a partir de um Objeto informado.
        /// </summary>
        /// <param name="cmd">Obtejo contendo valores. As props a serem atualizadas devem ter mesmo nome da entidade</param>
        /// <returns></returns>
        public bool AtualizaCliente(AtualizarClienteRequest cmd)
        {
            bool atualizou = false;
            
            foreach (PropertyInfo cliprop in typeof(Cliente).GetProperties().Where(p => p.CanWrite))
            {
                //regra negocio não atualiza documenot de cliente.
                //Se errou número ao cadastrar tem que excluir e cadastrar novamente.
                if (cliprop.Name.Equals("Documento"))  
                    continue;

                var cmdprop = cmd.GetType()
                              .GetProperties()
                              .Where(p => p.Name == cliprop.Name)
                              .First();

                if (!cliprop.GetValue(this, null).Equals(cmdprop.GetValue(cmd, null)))
                {
                    cliprop.SetValue(this, cmdprop.GetValue(cmd, null), null);
                    atualizou = true;
                }
            }
            return atualizou;
        }
    }
}
