using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Projeto.Teste.Cartao.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Cartao.Infraestrutura.Data.Repositorios
{
    public class PropostaRepositorio : GenericoRepositorio<Proposta>, IPropostaRepositorio
    {
        public PropostaRepositorio(AppDbContexto contexto, ILogger<PropostaRepositorio> logger) : base(contexto, logger)
        { }

        public async Task<List<Proposta>> ObterPropostaAsync(ExpressionStarter<Proposta> query)
        {
            return await _dbSet.Where(query).AsNoTracking().ToListAsync();
        }
    }
}
