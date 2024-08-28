using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Dominio.Migracoes;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validacoes;
using FluentMigrator.Runner;
using FluentValidation;
using LinqToDB;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;

namespace Cod3rsGrowth.Web.Injecao
{
    public static class ModuloDeInjecaoWeb
    {
        public static void ConfigurarServicos(this WebApplicationBuilder build) 
        {
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings[StringDeConexao.connectionString].ConnectionString;

            build.Services.AddScoped<ServicoMarca>();
            build.Services.AddScoped<ServicoTenis>();
            build.Services.AddScoped<IRepositorioTenis, RepositorioTenis>();
            build.Services.AddScoped<IRepositorioMarca, RepositorioMarca>();
            build.Services.AddScoped<IValidator<Tenis>, ValidacaoTenis>();
            build.Services.AddScoped<IValidator<Marca>, ValidacaoMarca>();

            build.Services.AddLinqToDBContext<DBCod3rsGrowth>((provider, options) => options
                .UseSqlServer(connection)
                .UseDefaultLogging(provider)
            );

            build.Services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(connection)
                    .ScanIn(typeof(_20240627102100_TabelaMarca).Assembly, typeof(_20240628090700_TabelaTenis).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());
        }
    }
}