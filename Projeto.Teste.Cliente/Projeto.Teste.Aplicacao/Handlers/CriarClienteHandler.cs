using Projeto.Teste.Dominio.Comandos.Request;
using Projeto.Teste.Dominio.Comandos.Response;
using Projeto.Teste.Dominio.DTO;
using Projeto.Teste.Dominio.Entidades;
using Projeto.Teste.Infraestrutura.Data.Repositorios;

namespace Projeto.Teste.Aplicacao.Handlers
{
    public class CriarClienteHandler : ICriarClienteHandler
    {
        private IClienteRepositorio<Cliente> _repocliente;
        private IUnitOfWork _uow;

        public CriarClienteHandler(IClienteRepositorio<Cliente> repocliente, IUnitOfWork uow)
        {
            _repocliente = repocliente;
            _uow = uow;
        }
        public async Task<Resultado<CriarClienteResponse>> Handle(CriarClienteRequest command)
        {
            try
            {
                Cliente cliente = new Cliente() 
                { 
                    Nome = command.Nome,
                    Email = command.Email,
                    Documento = command.Documento,
                    RG = command.RG,
                    DataNascimento = command.DataNascimento,
                    Fone = command.Fone
                };
                cliente.Validar();

                _uow.BeginTransaction();

                var clienteCriado = await _repocliente.CreateAsync(cliente);

                var result = await _uow.SaveChangesAsync();
                
                _uow.CommitTransaction();

                var resposta = new Resultado<CriarClienteResponse>(
                new CriarClienteResponse()
                {
                    Id = clienteCriado.Id,
                    Nome = clienteCriado.Nome,
                    DataCadastro = System.DateTime.Now,
                    Documento = clienteCriado.Documento,
                    Email = clienteCriado.Email,
                    Fone = clienteCriado.Fone,
                    RG = clienteCriado.RG,
                    DataNascimento = clienteCriado.DataNascimento
                    
                }, true, "Cliente cadastrado com sucesso");
                
                return resposta;
            }
            catch
            {
                _uow.RollbackTransaction();
                return new Resultado<CriarClienteResponse>(false, "Erro ao cadastrar cliente");
            }

        }
    }
}
