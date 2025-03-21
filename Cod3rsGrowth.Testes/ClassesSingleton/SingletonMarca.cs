﻿namespace Cod3rsGrowth.Testes.ClassesSingleton
{
    public sealed class SingletonMarca
    {
        public static List<Marca> InstanciaMarca = new();
        public static readonly List<Marca> marcas = new List<Marca>()
        {
            new Marca()
            {
                Cnpj = "42274696002561",
                Email = "comercial@adidasbrasil.com.br",
                Nome = "Adidas do Brasil LTDA",
                Telefone = "1155463700",
                Id = 1111,
            },
            new Marca() {
                Cnpj = "59546515004555",
                Email = "comercial@nikebrasil.com.br",
                Nome = "Nike do Brasil LTDA",
                Telefone = "1150399711",
                Id = 2222,
            },
            new Marca()
            {
                Cnpj = "07900208007704",
                Email = "comercial@vansbrasil.com.br",
                Nome = "Vans do Brasil LTDA",
                Telefone = "1156482955",
                Id = 3333,
            },
            new Marca()
            {
                Cnpj = "45075049000141",
                Email = "comercial@newbalance.com.br",
                Nome = "New Balance do Brasil LTDA",
                Telefone = "1123949704",
                Id = 4444,
            },
        };
        private SingletonMarca() { }
        public static List<Marca> Instancia
        {
            get
            {
                if (!InstanciaMarca.Any())
                {
                    InstanciaMarca = marcas;
                }
                return InstanciaMarca;
            }
        }
    }
}