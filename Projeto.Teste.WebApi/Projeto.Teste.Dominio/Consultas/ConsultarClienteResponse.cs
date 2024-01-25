using Projeto.Teste.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Dominio.Consultas.Response
{
    public class ConsultarClienteResponse
    {
        public ConsultarClienteResponse(Cliente cliente)
        {
            this.Id = cliente.Id;
            this.Nome = cliente.Nome;
            this.Email = cliente.Email;
            this.RG = cliente.RG;
            this.Documento = cliente.Documento;
            this.Fone = cliente.Fone;
            this.DataNascimento = cliente.DataNascimento;
        }
        public ConsultarClienteResponse()
        {
            
        }
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string? RG { get; set; }
        public string Documento { get; set; }
        public string? Fone { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
