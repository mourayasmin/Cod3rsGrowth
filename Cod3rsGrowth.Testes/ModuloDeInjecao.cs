using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes
{
    public class ModuloDeInjecao
    {
        public static void  BindService(IServiceCollection Services)
        {
            Services.AddScoped<IRepositorioTenis, RepositorioTenisMock>();
            Services.AddScoped<IRepositorioMarca, RepositorioMarcaMock>();
            Services.AddScoped<IServicoMarca, ServicoMarca>();
            Services.AddScoped<IServicoTenis, ServicoTenis>();
        }
    }
}
