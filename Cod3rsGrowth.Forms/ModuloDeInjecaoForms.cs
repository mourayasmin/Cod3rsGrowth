using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cod3rsGrowth.Forms
{
    public class ModuloDeInjecaoForms
    {
        public static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddScoped<RepositorioMarca>();
                    services.AddScoped<RepositorioTenis>();
                });
        }
    }
}
