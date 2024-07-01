using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Infra.Repositories;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validacoes;
using Cod3rsGrowth.Testes.RepositoriosMock;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Configuracoes
{
    public class ModuloDeInjecao
    {
        public static void BindService(IServiceCollection Services)
        {
            Services.AddScoped<IRepositorioTenis, RepositorioTenisMock>();
            Services.AddScoped<IRepositorioMarca, RepositorioMarcaMock>();
            Services.AddScoped<ServicoMarca>();
            Services.AddScoped<ServicoTenis>();
            Services.AddScoped<IValidator<Tenis>, ValidacaoTenis>();
            Services.AddScoped<IValidator<Marca>, ValidacaoMarca>();
        }
    }
}