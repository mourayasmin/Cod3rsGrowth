using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
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
            Application.Run(new TelaDeLista(_serviceProvider.GetRequiredService<ServicoMarca>(), _serviceProvider.GetRequiredService<ServicoTenis>()));
        }
    }
}