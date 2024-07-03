using static Cod3rsGrowth.Forms.Injecao.ModuloDeInjecaoForms;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Infra;
using LinqToDB;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Microsoft.Data.SqlClient;
using Cod3rsGrowth.Infra.Repositories;
using Cod3rsGrowth.Servicos.Injecao;
using Cod3rsGrowth.Infra.Injecao;
using System.Configuration;

namespace Cod3rsGrowth.Forms
{
    public class Program
    {
        private static IServiceProvider? _serviceProvider;

        [STAThread]
        static void Main()
        {
            var connection =
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            var colecaoDeServicos = new ServiceCollection();
            ModuloDeInjecaoServico.Configurar(colecaoDeServicos);
            ModuloDeInjecaoInfra.Configurar(colecaoDeServicos, connection);
            _serviceProvider = colecaoDeServicos.BuildServiceProvider();

            ModuloDeInjecaoInfra.RodarMigration(_serviceProvider);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(_serviceProvider.GetRequiredService<ServicoMarca>()));
        }
    }
}