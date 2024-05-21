using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Testes
{
    internal class TesteBase : IDisposable
    {
        protected ServiceProvider? ProviderService { get; private set; }
        public TesteBase() {
            var servico = new ServiceCollection();
            servico.AddScoped<IRepositorioMock, RepositorioMock>();
            ProviderService = servico.BuildServiceProvider();
        }
        public void Dispose()
        {
            ProviderService?.Dispose();
        }
    }
}
