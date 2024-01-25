using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Teste.Dominio.Consultas.Request;
using Projeto.Teste.Dominio.Consultas.Response;
using Projeto.Teste.Dominio.DTO;

namespace Projeto.Teste.Aplicacao.Handlers
{
    public interface IConsultaClienteHandler
    {
        Task<Resultado<IList<ConsultarClienteResponse>>> Handle(ConsultarClienteRequest request); 
    }
}
