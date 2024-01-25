using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Projeto.Teste.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Infraestrutura.Data.Repositorios
{
    public class ClienteRepositorio : GenericoRepositorio<Cliente>, IClienteRepositorio<Cliente>
    {
        public ClienteRepositorio(AppDbContexto contexto, ILogger<ClienteRepositorio> logger) : base(contexto, logger)
        { }

        public async Task<List<Cliente>> ObterClienteAsync(ExpressionStarter<Cliente> query)
        {
            return await _dbSet.Where(query).AsNoTracking().ToListAsync();
        }
    }
}
