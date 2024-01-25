using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto.Teste.Infraestrutura.Data.Repositorios;
using Projeto.Teste.Dominio.Entidades;

namespace Projeto.Teste.Infraestrutura.Data
{
    public static class ServicosExtencao
    {
        public static void AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MysqlConnection");
            services.AddDbContext<AppDbContexto>(opt =>
            {
                opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));


            });

            services.AddScoped<IClienteRepositorio<Cliente>, ClienteRepositorio>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
