using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes
{
    public class ModuloDeInjecao
    {
        public static ServiceCollection Servico { get; set; }
        public ModuloDeInjecao() {
            Servico = new ServiceCollection();
            Servico.AddScoped<IRepositorioMock, RepositorioMock>();
        }    
        public static ServiceProvider BuildServiceProvider()
        {
            return Servico.BuildServiceProvider();
        }
    }
}
