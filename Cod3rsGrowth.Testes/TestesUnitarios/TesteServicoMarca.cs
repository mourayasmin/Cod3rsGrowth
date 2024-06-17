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
using System.Text.RegularExpressions;

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
            var idMarca = 1111;
            var nomeMarca = "Adidas do Brasil LTDA";
            var telefoneMarca = 1155463700;
            var marcaRetornada = _servicoMarca.ObterPorId(idMarca);
            Assert.NotNull(marcaRetornada);
            Assert.Equal(idMarca, marcaRetornada.Id);
            Assert.Equal(nomeMarca, marcaRetornada.Nome);
            Assert.Equal(telefoneMarca, marcaRetornada.Telefone);
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
            Assert.NotNull(resultadoMarca);
            Assert.Equal(resultadoMarca, marca);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        public void Cnpj_Nulo_Ou_Vazio_Deve_Retornar_Erro(string Cnpj)
        {
            var marca = new Marca()
            {
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

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        public void Nome_Nulo_Ou_Vazio_Deve_Retornar_Erro(string Nome)
        {
            var marca = new Marca()
            {
                Cnpj = "65498732132165",
                Email = "oxerbrasil@oxer.com.br",
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

        [Fact]
        public void Deve_Retornar_Email_Da_Marca_Editado()
        {
            var Id = 1111;
            var marcaEditada = _servicoMarca.ObterPorId(Id);
            marcaEditada.Email = "contato@adidasbrasil.com.br";
            var marcaRetornada = _servicoMarca.Atualizar(marcaEditada, Id);
            Assert.Equal(marcaRetornada.Email, "contato@adidasbrasil.com.br");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]

        public void Deve_Retornar_Erro_Por_Email_Nulo_Ou_Vazio(string Email)
        {
            var Id = 1111;
            var marcaEditada = _servicoMarca.ObterPorId(Id);
            var marcaRetornada = _servicoMarca.Atualizar(marcaEditada, Id);
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoMarca.Atualizar(marcaRetornada, Id));
            Assert.Contains("Informe um e-mail válido.", mensagemDeErro.Message);
        }

        [Fact]
        public void Deve_Retornar_Telefone_Da_Marca_Editado()
        {
            var Id = 1111;
            var marcaEditada = _servicoMarca.ObterPorId(Id);
            marcaEditada.Telefone = 1112345678;
            var marcaRetornada = _servicoMarca.Atualizar(marcaEditada, Id);
            Assert.Equal(marcaRetornada.Telefone, 1112345678);
        }
    }
}