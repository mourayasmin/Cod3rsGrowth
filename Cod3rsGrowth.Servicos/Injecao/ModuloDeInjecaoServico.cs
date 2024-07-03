using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validacoes;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cod3rsGrowth.Servicos.Injecao
{
    public class ModuloDeInjecaoServico
    {
        public static void Configurar(IServiceCollection services)
        {
            services.AddScoped<ServicoMarca>();
            services.AddScoped<ServicoTenis>();
            services.AddScoped<IValidator<Tenis>, ValidacaoTenis>();
            services.AddScoped<IValidator<Marca>, ValidacaoMarca>();
        }
    }
}
