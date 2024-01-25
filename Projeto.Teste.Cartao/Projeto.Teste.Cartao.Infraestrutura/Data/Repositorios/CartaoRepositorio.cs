using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nscartao = Projeto.Teste.Cartao.Dominio.Entidades;

namespace Projeto.Teste.Cartao.Infraestrutura.Data.Repositorios
{
    public class CartaoRepositorio : GenericoRepositorio<nscartao.Cartao>, ICartaoRepositorio
    {
        public CartaoRepositorio(AppDbContexto contexto, ILogger<CartaoRepositorio> logger) : base(contexto, logger)
        { }

        public async Task<List<nscartao.Cartao>> ObterCartaoAsync(ExpressionStarter<nscartao.Cartao> query)
        {
            return await _dbSet.Where(query).AsNoTracking().ToListAsync();
        }
    }
}
