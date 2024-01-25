using Projeto.Teste.Dominio.Comandos;
using Projeto.Teste.Dominio.Comandos.Request;
using Projeto.Teste.Dominio.Comandos.Response;
using Projeto.Teste.Dominio.DTO;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Aplicacao.Handlers
{
    public interface IAtualizarClienteHandler
    {
        Task<Resultado<string>> Handle(AtualizarClienteRequest command);
    }
}
