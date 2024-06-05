using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Servicos.InterfacesServicos;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Testes.RepositoriosMock;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Configuracoes
{
    public class ModuloDeInjecao
    {
        public static void BindService(IServiceCollection Services)
        {
            Services.AddScoped<IRepositorioTenis, RepositorioTenisMock>();
            Services.AddScoped<IRepositorioMarca, RepositorioMarcaMock>();
            Services.AddScoped<IServicoMarca, ServicoMarca>();
            Services.AddScoped<IServicoTenis, ServicoTenis>();
        }
    }
}