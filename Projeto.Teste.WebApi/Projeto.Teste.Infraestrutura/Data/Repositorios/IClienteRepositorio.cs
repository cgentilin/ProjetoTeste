using LinqKit;
using Projeto.Teste.Dominio.Entidades;

namespace Projeto.Teste.Infraestrutura.Data.Repositorios
{
    public interface IClienteRepositorio<T> : IGenericoRepositorio<Cliente> where T : class
    {
        Task<List<Cliente>> ObterClienteAsync(ExpressionStarter<Cliente> query);
    
    }
}
