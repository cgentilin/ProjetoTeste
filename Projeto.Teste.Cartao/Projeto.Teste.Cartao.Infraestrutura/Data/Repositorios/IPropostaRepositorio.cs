using LinqKit;
using Projeto.Teste.Cartao.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Cartao.Infraestrutura.Data.Repositorios
{
    public interface IPropostaRepositorio : IGenericoRepositorio<Proposta>
    {
        Task<List<Proposta>> ObterPropostaAsync(ExpressionStarter<Proposta> query);
    }
}
