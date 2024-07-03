using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Infra.Repositories;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validacoes;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cod3rsGrowth.Forms.Injecao
{
    public class ModuloDeInjecaoForms
    {
        public static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<ServicoMarca>();
                    services.AddScoped<ServicoTenis>();
                    services.AddScoped<IValidator<Tenis>, ValidacaoTenis>();
                    services.AddScoped<IValidator<Marca>, ValidacaoMarca>();
                    services.AddScoped<IRepositorioMarca, RepositorioMarca>();
                    services.AddScoped<IRepositorioTenis, RepositorioTenis>();
                    services.AddScoped<Form1>();
                });
        }
    }
}
