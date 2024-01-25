using Microsoft.Extensions.Logging;
using Projeto.Teste.Dominio.Comandos;
using Projeto.Teste.Dominio.DTO;
using Projeto.Teste.Dominio.Entidades;
using Projeto.Teste.Infraestrutura.Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Aplicacao.Handlers
{
    public class AtualizarClienteHandler : IAtualizarClienteHandler
    {
        private IClienteRepositorio<Cliente> _repo;
        private ILogger<AtualizarClienteHandler> _loger;
        private IUnitOfWork _uow;

        public AtualizarClienteHandler(
            IClienteRepositorio<Cliente> repo, 
            ILogger<AtualizarClienteHandler> loger,
            IUnitOfWork uow
            )
        {
            _repo = repo;
            _loger = loger;
            _uow = uow; 
        }
        public async Task<Resultado<string>> Handle(AtualizarClienteRequest commando)
        {
            var cliente = await _repo.GetByIdAsync(commando.Id);
            
            if (cliente is null)
                throw new Exception($"Cliente não encontrado Identificador {commando.Id}");

            Resultado<string> resultado = null;

            try
            {
                if (cliente.AtualizaCliente(commando))
                {
                    _uow.BeginTransaction();
                    await _repo.UpdateAsync(cliente);
                    await _uow.SaveChangesAsync();
                    _uow.CommitTransaction();
                }
                
                _loger.LogInformation($"cliente atualizado com sucesso id {commando.Id}");

                return new Resultado<string>(true, "Cliente atualizado com sucesso");
                
            }
            catch(Exception ex)
            {
                _loger.LogError($"Erro ao atualizar o cliente id {commando.Id} exception: {ex.Message}");
                _uow.RollbackTransaction();
                return new Resultado<string>(false, "Erro ao atualizar Cliente");
            }
        }
    }
}
