using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Teste.Cartao.Infraestrutura.Data.Repositorios;
using UOW = Projeto.Teste.Cartao.Infraestrutura.Data.UnitOfWork;

namespace Projeto.Teste.Cartao.Infraestrutura.Data
{
    public static class InfraestruturaIoC
    {
        public static void AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MysqlConnection");
            services.AddDbContext<AppDbContexto>(opt =>
            {
                opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            services.AddScoped<IPropostaRepositorio, PropostaRepositorio>();
            services.AddScoped<UOW.IUnitOfWork, UOW.UnitOfWork>();
            services.AddScoped<ICartaoRepositorio, CartaoRepositorio>();

        }
    }
}
