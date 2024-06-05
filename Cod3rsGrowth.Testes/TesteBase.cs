using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Testes
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