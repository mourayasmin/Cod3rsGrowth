using Cod3rsGrowth.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using Cod3rsGrowth.Testes.Configuracoes;
using Cod3rsGrowth.Servicos.InterfacesServicos;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Testes.ClassesSingleton;
using Cod3rsGrowth.Testes.Validacoes;
using Cod3rsGrowth.Servicos.Validacoes;
using FluentValidation;

namespace Cod3rsGrowth.Testes.TestesUnitarios
{
    public class TesteServicoTenis : TesteBase
    {
        protected IServicoTenis? _servicoTenis;
        public TesteServicoTenis()
        {
            _servicoTenis = ProviderService?.GetService<IServicoTenis>();
        }

        [Fact]
        public void Deve_Retornar_Lista_De_Tenis_Cadastrados()
        {
            var listaDeTenis = _servicoTenis.ObterTodos();
            Assert.NotNull(listaDeTenis);
            Assert.Equal(4, listaDeTenis.Count);
        }

        [Fact]
        public void Deve_Retornar_Tenis_Atraves_Do_Id_Informado()
        {
            var idTenisEsperado = 0001;
            var nomeTenisEsperado = "Streetball";
            var idMarcaEsperada = 1111;
            var tenisRetornado = _servicoTenis.ObterPorId(idTenisEsperado);
            Assert.NotNull(tenisRetornado);
            Assert.Equal(idTenisEsperado, tenisRetornado.Id);
            Assert.Equal(nomeTenisEsperado, tenisRetornado.Nome);
            Assert.Equal(idMarcaEsperada, tenisRetornado.Idmarca);
        }

        [Theory]
        [InlineData(0000)]
        [InlineData(0007)]
        [InlineData(87087)]
        public void Deve_Retornar_Mensagem_De_Erro_Pelo_Id_De_Tenis_Inexistente(int Id)
        {
            var mensagemDeErro = Assert.Throws<ArgumentException>(() => _servicoTenis.ObterPorId(Id));
            Assert.Contains("O Id informado é inválido.", mensagemDeErro.Message);
        }

        [Fact]
        public void Deve_Retornar_Tenis_Criado()
        {
            var tenisCriado = new Tenis()
            {
                Linha = Dominio.Enum.LinhaEnum.Casual,
                Id = 0005,
                Idmarca = 1111,
                Preco = 399.99,
                Lancamento = DateTime.Parse("14/02/2018"),
                Avaliacao = 9.7M,
                Nome = "Pharrell Williams Hu",
                Disponibilidade = false
            };

            var resultadoTenis = _servicoTenis.Criar(tenisCriado);
            Assert.NotNull(resultadoTenis);
            Assert.Equal(resultadoTenis, tenisCriado);
            var a = SingletonTenis.Instancia.Contains(resultadoTenis);
            Assert.IsType<Tenis>(resultadoTenis);
        }

        [Fact]
        public void Linha_Nula_Deve_Retornar_Erro()
        {
            var tenisCriado = new Tenis()
            {
                Linha = null,
                Id = 0005,
                Idmarca = 1111,
                Preco = 399.99,
                Lancamento = DateTime.Parse("14/02/2018"),
                Avaliacao = 9.7M,
                Nome = "Pharrell Williams Hu",
                Disponibilidade = false
            };

            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoTenis.Criar(tenisCriado));
            Assert.Contains("A linha informada é inválida.", mensagemDeErro.Message);
        }
        [Theory]
        [InlineData(null)]
        public void Tipo_De_Linha_Diferente_De_Enum_Deve_Retornar_Erro(double Preco)
        { 
            var tenisCriado = new Tenis()
            {
                Linha = Dominio.Enum.LinhaEnum.Casual,
                Id = 0005,
                Idmarca = 1111,
                Lancamento = DateTime.Parse("14/02/2018"),
                Avaliacao = 9.7M,
                Nome = "Pharrell Williams Hu",
                Disponibilidade = false
            };


        }
    }
}