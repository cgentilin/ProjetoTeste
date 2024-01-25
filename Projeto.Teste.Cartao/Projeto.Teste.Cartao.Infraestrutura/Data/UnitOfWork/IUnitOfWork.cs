using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Cartao.Infraestrutura.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void BeginTransaction(IsolationLevel nivelIsolamenot);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
