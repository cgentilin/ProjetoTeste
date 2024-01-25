using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Teste.Dominio.Comandos.Request;
using Projeto.Teste.Dominio.Comandos.Response;
using Projeto.Teste.Dominio.DTO;

namespace Projeto.Teste.Aplicacao.Handlers
{
    public interface ICriarClienteHandler
    {
        Task<Resultado<CriarClienteResponse>> Handle(CriarClienteRequest command);
    }
}
