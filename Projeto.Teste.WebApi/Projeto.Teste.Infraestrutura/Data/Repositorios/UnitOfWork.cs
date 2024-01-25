using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Infraestrutura.Data.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContexto _dbContexto;
        private ILogger<UnitOfWork> _log;
        
        //private IDbTransaction _transacao;
        private IDbContextTransaction _transacao;
        public UnitOfWork(AppDbContexto contexto, ILogger<UnitOfWork> log)
        {
            _dbContexto = contexto;
            _log = log;
        }
        //public IDbTransaction BeginTransaction()
        //{
        //    var transacao = _dbContexto.Database.BeginTransaction();
        //    return transacao.GetDbTransaction();
        //}

        /// <summary>
        /// Inicia uma transação com nível de isolamento padrão "Read Commited"
        /// </summary>
        public void BeginTransaction()
        {
            //_transacao = _dbContexto.Database.BeginTransaction().GetDbTransaction();
            _transacao = _dbContexto.Database.BeginTransaction();
        }

        /// <summary>
        /// Commita a transação iniciada
        /// </summary>
        public void CommitTransaction()
        {
            if(_transacao != null)
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
