using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Dominio.Comandos
{
    public class AtualizarClienteRequest
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string? RG { get; set; }
        public string Documento { get; set; }
        public string? Fone { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
