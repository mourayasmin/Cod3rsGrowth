using static Cod3rsGrowth.Forms.ModuloDeInjecaoForms;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms
{
    public class Program
    {

        [STAThread]
        static void Main()
        {
            using (var serviceProvider = CreateServices())
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            var host = CreateHostBuilder().Build();
            ProviderService = host.Services;
            Application.Run(ProviderService.GetRequiredService<Form1>());
        }

        public static IServiceProvider ProviderService { get; private set; }

        private static ServiceProvider CreateServices()
        {
            var connection =
            System.Configuration.ConfigurationManager.
            ConnectionStrings["ConnectionString"].ConnectionString;
            return new ServiceCollection()
                       .AddFluentMigratorCore()
                        .ConfigureRunner(rb => rb
                            .AddSqlServer()
                            .WithGlobalConnectionString(connection)
                            .ScanIn(typeof(Marca).Assembly).For.Migrations())
                        .AddLogging(lb => lb.AddFluentMigratorConsole())
                        .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}