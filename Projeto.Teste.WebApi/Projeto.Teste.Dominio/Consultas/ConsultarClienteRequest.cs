using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Dominio.Consultas.Request
{
    /// <summary>
    /// Consultar apenas pelos campos indexados. Para adicionar mais criar novos índices no banco dados.
    /// </summary>
    public class ConsultarClienteRequest
    {
        public int? Id { get; set; }
        public string? Email { get; set; }
        public string? Documento { get; set; }
    }
}
