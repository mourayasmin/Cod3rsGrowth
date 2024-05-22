using Microsoft.Extensions.DependencyInjection;
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
        protected ServiceProvider? ProviderService;
        public TesteBase() {
            var servico = new ServiceCollection();
            ProviderService = servico.BuildServiceProvider();
        }

        public void Dispose()
        {
            ProviderService?.Dispose();
        }
    }

    internal interface IMock
    {
    }
}
