﻿using Cod3rsGrowth.Testes.ClassesSingleton;
using Cod3rsGrowth.Testes.Configuracoes;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Testes.TestesUnitarios
{
    public class TesteServicoTenis : TesteBase
    {
        private  ServicoTenis _servicoTenis;
        public TesteServicoTenis()
        {
            _servicoTenis = ProviderService?.GetService<ServicoTenis>();
            SingletonTenis.Instancia.Clear();
        }

        [Fact]
        public void deve_retornar_lista_de_tenis_cadastrados()
        {
            SingletonTenis.Instancia.AddRange(new List<Tenis> { new Tenis(), new Tenis() });
            var listaDeTenis = _servicoTenis.ObterTodos(null);
            Assert.NotNull(listaDeTenis);
            const int quantidadeDeTenisNaLista = 2;
            Assert.Equal(quantidadeDeTenisNaLista, listaDeTenis.Count);
        }

        [Fact]
        public void deve_retornar_tenis_atraves_do_id_informado()
        {
            var tenisEsperado = new Tenis()
            {
                Id = 0001,
                Nome = "Streetball",
                IdMarca = 1111
            };
            SingletonTenis.Instancia.Add(tenisEsperado);
            var tenisRetornado = _servicoTenis.ObterPorId(tenisEsperado.Id);

            Assert.NotNull(tenisRetornado);
            Assert.Equal(tenisEsperado.Id, tenisRetornado.Id);
            Assert.Equal(tenisEsperado.Nome, tenisRetornado.Nome);
            Assert.Equal(tenisEsperado.IdMarca, tenisRetornado.IdMarca);
        }

        [Theory]
        [InlineData(0000)]
        [InlineData(0007)]
        [InlineData(87087)]
        public void deve_retornar_erro_por_id_de_tenis_inexistente(int idTenisInexistente)
        {
            var mensagemDeErro = Assert.Throws<ArgumentException>(() => _servicoTenis.ObterPorId(idTenisInexistente));
            Assert.Contains("O Id informado é inválido.", mensagemDeErro.Message);
        }

        [Fact]
        public void deve_retornar_tenis_criado()
        {
            var tenisCriado = new Tenis()
            {
                Linha = Dominio.Enum.LinhaEnum.Casual,
                Id = 0005,
                IdMarca = 1111,
                Preco = 399.99,
                Lancamento = DateTime.Parse("14/02/2018"),
                Avaliacao = 9.7M,
                Nome = "Pharrell Williams Hu",
                Disponibilidade = false
            };
            var resultadoTenis = _servicoTenis.Criar(tenisCriado);
            Assert.NotNull(resultadoTenis);
            Assert.Equal(resultadoTenis, tenisCriado);
        }

        [Fact]
        public void deve_retornar_erro_por_linha_nula()
        {
            var tenisCriado = new Tenis()
            {
                Linha = null,
                Id = 0005,
                IdMarca = 1111,
                Preco = 399.99,
                Lancamento = DateTime.Parse("14/02/2018"),
                Avaliacao = 9.7M,
                Nome = "Pharrell Williams Hu",
                Disponibilidade = false
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoTenis.Criar(tenisCriado));
            Assert.Contains("Informe o nome da linha.", mensagemDeErro.Message);
        }

        [Fact]
        public void deve_retornar_erro_por_preco_nulo()
        {
            var tenisCriado = new Tenis()
            {
                Linha = Dominio.Enum.LinhaEnum.Casual,
                Id = 0005,
                IdMarca = 1111,
                Preco = null,
                Lancamento = DateTime.Parse("14/02/2018"),
                Avaliacao = 9.7M,
                Nome = "Pharrell Williams Hu",
                Disponibilidade = false
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoTenis.Criar(tenisCriado));
            Assert.Contains("Informe o preço do produto.", mensagemDeErro.Message);
        }

        [Fact]
        public void deve_retornar_erro_por_preco_igual_a_zero_()
        { 
            var tenisCriado = new Tenis()
            {
                Linha = Dominio.Enum.LinhaEnum.Casual,
                Id = 0005,
                IdMarca = 1111,
                Preco = 0.0,
                Lancamento = DateTime.Parse("14/02/2018"),
                Avaliacao = 9.7M,
                Nome = "Pharrell Williams Hu",
                Disponibilidade = false
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoTenis.Criar(tenisCriado));
            Assert.Contains("O preço informado é inválido.", mensagemDeErro.Message);
        }

        [Fact]
        public void deve_retornar_erro_por_preco_menor_que_zero()
        {
            var tenisCriado = new Tenis()
            {
                Linha = Dominio.Enum.LinhaEnum.Casual,
                Id = 0005,
                IdMarca = 1111,
                Preco = -32.0,
                Lancamento = DateTime.Parse("14/02/2018"),
                Avaliacao = 9.7M,
                Nome = "Pharrell Williams Hu",
                Disponibilidade = false
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoTenis.Criar(tenisCriado));
            Assert.Contains("O preço informado é inválido.", mensagemDeErro.Message);
        }

        [Fact]
        public void deve_retornar_erro_por_avaliacao_menor_que_zero()
        {
            var tenisCriado = new Tenis()
            {
                Linha = Dominio.Enum.LinhaEnum.Casual,
                Id = 0005,
                IdMarca = 1111,
                Preco = 399.99,
                Lancamento = DateTime.Parse("14/02/2018"),
                Avaliacao = -3.0M,
                Nome = "Pharrell Williams Hu",
                Disponibilidade = false
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoTenis.Criar(tenisCriado));
            Assert.Contains("A avaliação informada é inválida. Informe uma avaliação de 0 a 10.", mensagemDeErro.Message);
        }

        [Fact]
        public void deve_retornar_erro_por_avaliacao_maior_que_dez()
        {
            var tenisCriado = new Tenis()
            {
                Linha = Dominio.Enum.LinhaEnum.Casual,
                Id = 0005,
                IdMarca = 1111,
                Preco = 399.99,
                Lancamento = DateTime.Parse("14/02/2018"),
                Avaliacao = 11.0M,
                Nome = "Pharrell Williams Hu",
                Disponibilidade = false
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoTenis.Criar(tenisCriado));
            Assert.Contains("A avaliação informada é inválida. Informe uma avaliação de 0 a 10.", mensagemDeErro.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        public void deve_retornar_erro_por_nome_nulo_ou_vazio(string nome)
        {
            var tenisCriado = new Tenis()
            {
                Nome = nome,
                Linha = Dominio.Enum.LinhaEnum.Casual,
                Id = 0005,
                IdMarca = 1111,
                Preco = 399.99,
                Lancamento = DateTime.Parse("14/02/2018"),
                Avaliacao = 11.0M,
                Disponibilidade = false
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoTenis.Criar(tenisCriado));
            Assert.Contains("O nome do tênis está vazio.", mensagemDeErro.Message);
        }

        [Fact]
        public void deve_retornar_tenis_editado_com_sucesso()
        {
            var tenisEditado = new Tenis()
            {
                Linha = Dominio.Enum.LinhaEnum.Casual,
                Id = 0001,
                IdMarca = 1111,
                Preco = 599.99,
                Lancamento = DateTime.Parse("27/03/2020"),
                Avaliacao = 5.2M,
                Nome = "Streetball",
                Disponibilidade = false,
            };
            SingletonTenis.Instancia.Add(tenisEditado);
            var tenisRetornado = _servicoTenis.Atualizar(tenisEditado);
            Assert.Equivalent(tenisEditado, tenisRetornado);
        }

        [Fact]
        public void deve_retornar_erro_por_preco_editado_invalido()
        {
            var tenisEditado = new Tenis()
            {
                Linha = Dominio.Enum.LinhaEnum.Casual,
                Id = 0001,
                IdMarca = 1111,
                Preco = -250.00,
                Lancamento = DateTime.Parse("27/03/2020"),
                Avaliacao = 5.2M,
                Nome = "Streetball",
                Disponibilidade = false,
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoTenis.Atualizar(tenisEditado));
            Assert.Contains("O preço informado é inválido.", mensagemDeErro.Message);
        }

        [Theory]
        [InlineData(-3)]
        [InlineData(11)]
        public void deve_retornar_erro_por_avaliacao_editada_invalida(decimal avaliacao)
        {
            var tenisEditado = new Tenis()
            {
                Linha = Dominio.Enum.LinhaEnum.Casual,
                Id = 0001,
                IdMarca = 1111,
                Preco = 549.99,
                Lancamento = DateTime.Parse("27/03/2020"),
                Avaliacao = avaliacao,
                Nome = "Streetball",
                Disponibilidade = false,
            };
            SingletonTenis.Instancia.Add(tenisEditado);
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoTenis.Atualizar(tenisEditado));
            Assert.Contains("A avaliação informada é inválida. Informe uma avaliação de 0 a 10.", mensagemDeErro.Message);
        }

        [Fact]
        public void deve_retornar_erro_por_tenis_nulo()
        {
            Tenis tenisRetornado = null;
            SingletonTenis.Instancia.Add(tenisRetornado);
            var mensagemDeErro = Assert.Throws<Exception>(() => _servicoTenis.Atualizar(tenisRetornado));
            Assert.Contains("O tênis não foi informado.", mensagemDeErro.Message);
        }

        [Fact]
        public void deve_remover_tenis_com_sucesso()
        {
            var tenisASerDeletado = new Tenis()
            {
                Linha = Dominio.Enum.LinhaEnum.Casual,
                Id = 4321,
                IdMarca = 1111,
                Preco = 549.99,
                Lancamento = DateTime.Parse("27/03/2020"),
                Avaliacao = 9.7M,
                Nome = "Streetball",
                Disponibilidade = false,
            };
            SingletonTenis.Instancia.Add(tenisASerDeletado);
            _servicoTenis.Deletar(tenisASerDeletado.Id);
            var tenisParaDeletar = SingletonTenis.Instancia.Find(tenis => tenis.Id == tenisASerDeletado.Id);
            Assert.Null(tenisParaDeletar);
        }
    }
}