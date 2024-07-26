using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Dominio.Migracoes;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Infra;
using FluentMigrator.Runner;
using LinqToDB.AspNet;
using LinqToDB;
using LinqToDB.AspNet.Logging;

namespace Cod3rsGrowth.Web.Injecao
{
    public static class ConfiguracaoInfra
    {
        public static void Configurar(this WebApplicationBuilder build, IServiceCollection services, string stringDeConexao)
        {
            build.Services.AddLinqToDBContext<DBCod3rsGrowth>((provider, options) => options
            .UseSqlServer(stringDeConexao)
            .UseDefaultLogging(provider)
            );

            build.Services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(stringDeConexao)
                    .ScanIn(typeof(_20240627102100_TabelaMarca).Assembly, typeof(_20240628090700_TabelaTenis).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());

            services.AddScoped<IRepositorioMarca, RepositorioMarca>();
            services.AddScoped<IRepositorioTenis, RepositorioTenis>();
        }
    }
}