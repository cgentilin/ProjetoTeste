using LinqKit;
using Microsoft.Extensions.Logging;
using Projeto.Teste.Cartao.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nscartao = Projeto.Teste.Cartao.Dominio.Entidades;

namespace Projeto.Teste.Cartao.Infraestrutura.Data.Repositorios
{
    public interface ICartaoRepositorio : IGenericoRepositorio<nscartao.Cartao>
    {
        Task<List<nscartao.Cartao>> ObterCartaoAsync(ExpressionStarter<nscartao.Cartao> query);
    }
}
