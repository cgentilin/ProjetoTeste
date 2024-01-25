using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Cartao.Infraestrutura.Data.Repositorios
{
    public class GenericoRepositorio<T> : IGenericoRepositorio<T> where T : class
    {
        protected DbSet<T> _dbSet;
        protected AppDbContexto _dbcontexto;
        protected readonly ILogger _logger;

        public GenericoRepositorio(AppDbContexto contexto, ILogger<GenericoRepositorio<T>> logger)
        {
            _dbcontexto = contexto;
            _logger = logger;
            _dbSet = _dbcontexto.Set<T>();
        }
        public async Task<T> CreateAsync(T entidade)
        {
            try
            {
                await _dbSet.AddAsync(entidade);
                return entidade;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao criar Entidade");
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entidade = await _dbSet.FindAsync(id);
                if (entidade != null)
                {
                    _dbSet.Remove(entidade);
                    return true;
                }
                else
                {
                    _logger.LogWarning("Entidade com id {Id} não foi encontrada", id);
                    return false;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error ao excluir entidade id {Id}", id);
                return false;
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Entidade não encontrada id {Id}", id);
                return null;
            }
        }

        public T Update(T entidade)
        {
            //_dbSet.Attach(entidade);
            //_dbSet.Entry(entidade).State = EntityState.Modified;
            _dbSet.Update(entidade);
            return entidade;
        }
        public IQueryable<T> GetByQuery(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }
    }
}
