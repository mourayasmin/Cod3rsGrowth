﻿using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Microsoft.Extensions.DependencyInjection;
using LinqToDB;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using Cod3rsGrowth.Infra.Repositorios;
using System;
using FluentMigrator.Runner;
using Cod3rsGrowth.Dominio.Migracoes;

namespace Cod3rsGrowth.Infra.Injecao
{
    public class ModuloDeInjecaoInfra
    {
        public static void Configurar(IServiceCollection services, string stringDeConexao)
        {
            services.AddLinqToDBContext<DBCod3rsGrowth>((provider, options) => options
                .UseSqlServer(stringDeConexao)
                .UseDefaultLogging(provider)
            );

            services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(stringDeConexao)
                    .ScanIn(typeof(_20240627102100_TabelaMarca).Assembly, typeof(_20240628090700_TabelaTenis).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());

            services.AddScoped<IRepositorioMarca, RepositorioMarca>();
            services.AddScoped<IRepositorioTenis, RepositorioTenis>();
        }

        public static void RodarMigration(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}
