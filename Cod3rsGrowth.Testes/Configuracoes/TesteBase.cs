using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Configuracoes
{
    public class TesteBase : IDisposable
    {
        protected ServiceProvider? ProviderService;
        public TesteBase()
        {
            ProviderService = ExecutarServiceCollection().BuildServiceProvider();
        }
        public IServiceCollection ExecutarServiceCollection()
        {
            var servicos = new ServiceCollection();
            ModuloDeInjecao.BindService(servicos);
            return servicos;
        }
        public void Dispose()
        {
            ProviderService?.Dispose();
        }
    }
}