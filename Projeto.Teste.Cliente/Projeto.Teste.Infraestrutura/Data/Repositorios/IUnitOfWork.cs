using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.CompilerServices;

namespace Projeto.Teste.Infraestrutura.Data.Repositorios
{
    public interface IUnitOfWork
    {
        //IDbTransaction BeginTransaction();
        //IDbTransaction BeginTransaction(IsolationLevel nivelIsolamenot);
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void BeginTransaction(IsolationLevel nivelIsolamenot);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
