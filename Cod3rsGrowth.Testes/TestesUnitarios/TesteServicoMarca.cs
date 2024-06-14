using Cod3rsGrowth.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.Configuracoes;
using Cod3rsGrowth.Servicos.InterfacesServicos;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Testes.ClassesSingleton;
using Cod3rsGrowth.Servicos.Validacoes;
using FluentValidation;

namespace Cod3rsGrowth.Testes.TestesUnitarios
{
    public class TesteServicoMarca : TesteBase
    {
        protected IServicoMarca? _servicoMarca;
        public TesteServicoMarca()
        {
            _servicoMarca = ProviderService?.GetService<IServicoMarca>();
        }

        [Fact]
        public void Obter_Lista_De_Marcas_Cadastradas()
        {
            var listaDeMarcas = _servicoMarca.ObterTodas();
            Assert.NotNull(listaDeMarcas);
            Assert.Equal(4, listaDeMarcas.Count);
        }

        [Fact]
        public void Deve_Retornar_Marca_Atraves_Do_Id_De_Marca_Informado()
        {
            var idMarcaEsperada = 1111;
            var nomeMarcaEsperada = "Adidas do Brasil LTDA";
            var telefoneMarcaEsperada = 1155463700;
            var marcaRetornada = _servicoMarca.ObterPorId(idMarcaEsperada);
            Assert.NotNull(marcaRetornada);
            Assert.Equal(idMarcaEsperada, marcaRetornada.Id);
            Assert.Equal(nomeMarcaEsperada, marcaRetornada.Nome);
            Assert.Equal(telefoneMarcaEsperada, marcaRetornada.Telefone);
        }

        [Theory]
        [InlineData(0000)]
        [InlineData(45669)]
        [InlineData(87087)]
        public void Ao_Obter_Por_Id_De_Marca_Inexistente_Deve_Retornar_Exceção(int Id)
        {
            var mensagemDeErro = Assert.Throws<ArgumentException>(() => _servicoMarca.ObterPorId(Id));
            Assert.Contains("O Id informado é inválido.", mensagemDeErro.Message);
        }

        [Fact]
        public void Deve_Retornar_Marca_Criada()
        {
            var marca = new Marca()
            {
                Cnpj = "65498732132165",
                Email = "oxerbrasil@oxer.com.br",
                Nome = "Oxer do Brasil LTDA",
                Telefone = 1158963256,
                Id = 6666
            };
            var resultadoMarca = _servicoMarca.Criar(marca);
            Assert.Equal(resultadoMarca, marca);
        }

        [Fact]
        public void Cnpj_Nulo_Deve_Retornar_Erro()
        {
            var marca = new Marca()
            {
                Cnpj = null,
                Email = "oxerbrasil@oxer.com.br",
                Nome = "Oxer do Brasil LTDA",
                Telefone = 1158963256,
                Id = 6666
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoMarca.Criar(marca));
            Assert.Contains("Informe o CNPJ da marca.", mensagemDeErro.Message);
        }

        [Fact]
        public void Cnpj_Vazio_Deve_Retornar_Erro()
        {
            var marca = new Marca()
            {
                Cnpj = " ",
                Email = "oxerbrasil@oxer.com.br",
                Nome = "Oxer do Brasil LTDA",
                Telefone = 1158963256,
                Id = 6666
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoMarca.Criar(marca));
            Assert.Contains("Informe o CNPJ da marca.", mensagemDeErro.Message);
        }

        [Fact]
        public void Cnpj_De_Tamanho_Errado_Deve_Retornar_Erro()
        {
            var marca = new Marca()
            {
                Cnpj = "654987321321",
                Email = "oxerbrasil@oxer.com.br",
                Nome = "Oxer do Brasil LTDA",
                Telefone = 1158963256,
                Id = 6666
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoMarca.Criar(marca));
            Assert.Contains("Informe um CNPJ válido.", mensagemDeErro.Message);
        }

        [Fact]
        public void Nome_Da_Marca_Nulo_Deve_Retornar_Erro()
        {
            var marca = new Marca()
            {
                Cnpj = "65498732132165",
                Email = "oxerbrasil@oxer.com.br",
                Nome = null,
                Telefone = 1158963256,
                Id = 6666
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoMarca.Criar(marca));
            Assert.Contains("O nome da marca está vazio.", mensagemDeErro.Message);
        }

        [Fact]
        public void Nome_Da_Marca_Vazio_Deve_Retornar_Erro()
        {
            var marca = new Marca()
            {
                Cnpj = "65498732132165",
                Email = "oxerbrasil@oxer.com.br",
                Nome = " ",
                Telefone = 1158963256,
                Id = 6666
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoMarca.Criar(marca));
            Assert.Contains("O nome da marca está vazio.", mensagemDeErro.Message);
        }

        [Fact]
        public void Id_Da_Marca_Nulo_Deve_Retornar_Erro()
        {
            var marca = new Marca()
            {
                Cnpj = "65498732132165",
                Email = "oxerbrasil@oxer.com.br",
                Nome = "Oxer do Brasil LTDA",
                Telefone = 1158963256,
                Id = null
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoMarca.Criar(marca));
            Assert.Contains("O Id está vazio.", mensagemDeErro.Message);
        }
    }
}