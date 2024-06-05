﻿using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes
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