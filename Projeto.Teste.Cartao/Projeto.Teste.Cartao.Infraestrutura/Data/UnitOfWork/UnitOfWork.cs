using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Projeto.Teste.Cartao.Infraestrutura.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContexto _dbContexto;
        private ILogger<UnitOfWork> _log;
        private IDbContextTransaction _transacao;
        public UnitOfWork(AppDbContexto contexto, ILogger<UnitOfWork> log)
        {
            _dbContexto = contexto;
            _log = log;
        }

        /// <summary>
        /// Inicia uma transação com nível de isolamento padrão "Read Commited"
        /// </summary>
        public void BeginTransaction()
        {
            _transacao = _dbContexto.Database.BeginTransaction();
        }

        /// <summary>
        /// Commita a transação iniciada
        /// </summary>
        public void CommitTransaction()
        {
            if (_transacao != null)
                _transacao.Commit();
        }

        /// <summary>
        /// Faz Rollback da transação iniciada
        /// </summary>
        public void RollbackTransaction()
        {
            if (_transacao != null)
                _transacao.Rollback();
        }

        /// <summary>
        /// Inicia uma transação e define um nível de isolamento
        /// </summary>
        /// <param name="nivelIsolamenot">nível de isolamento</param>
        public void BeginTransaction(IsolationLevel nivelIsolamenot)
        {
            _transacao = _dbContexto.Database.BeginTransaction(nivelIsolamenot);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dbContexto.SaveChangesAsync(cancellationToken);
        }
    }
}