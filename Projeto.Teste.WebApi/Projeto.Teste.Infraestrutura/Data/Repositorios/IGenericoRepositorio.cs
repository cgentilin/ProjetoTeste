using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Infraestrutura.Data.Repositorios
{
    public interface IGenericoRepositorio<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        IQueryable<T> GetByQuery(Expression<Func<T, bool>> predicate);
        Task<T> CreateAsync(T entidade);
        Task<T> UpdateAsync(T entidade);
        Task<bool> DeleteAsync(int id);
    }
}
