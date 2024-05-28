using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio.Enum;
using Cod3rsGrowth.Dominio;

namespace Cod3rsGrowth.Infra
{
    public sealed class SingletonTenis
    {
        private static List<Tenis> InstanciaTenis = new();
        private static readonly List<Tenis> tenis = new List<Tenis>()
        {
            new Tenis()
            {
                Linha = LinhaEnum.Casual,
                Id = 0001,
                Idmarca = 1111,
                Preco = 549.99,
                Lancamento = DateTime.Parse("27/03/2020"),
                Avaliacao = 8.9M,
                Nome = "Streetball",
                Disponibilidade = true,
            },
            new Tenis()
            {
                Linha = LinhaEnum.Corrida,
                Id = 0002,
                Idmarca = 2222,
                Preco = 1899.99,
                Lancamento = DateTime.Parse("02/04/2023"),
                Avaliacao = 9.2M,
                Nome = "Alphafly 2",
                Disponibilidade = true,
            },
            new Tenis()
            {
                Linha =LinhaEnum.Skate,
                Id = 0003,
                Idmarca = 3333,
                Preco = 599.99,
                Lancamento = DateTime.Parse("14/01/2024"),
                Avaliacao = 9.0M,
                Nome = "Knu Skool",
                Disponibilidade = true,
            },
            new Tenis()
            {
                Linha = LinhaEnum.Casual,
                Id = 0004,
                Idmarca = 4444,
                Preco = 999.99,
                Lancamento = DateTime.Parse("12/05/2021"),
                Avaliacao = 9.5M,
                Nome = "New Balance 550",
                Disponibilidade = true,
            },
        };
        private SingletonTenis() { }
        public static List<Tenis> Instancia
        {
               get
            {
                if(InstanciaTenis == null)
                {
                    InstanciaTenis = tenis;
                }
                return InstanciaTenis;
            }
        }
    }
}
