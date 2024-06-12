using Cod3rsGrowth.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.Configuracoes;
using Cod3rsGrowth.Servicos.InterfacesServicos;
using Cod3rsGrowth.Servicos.Servicos;
using System.ComponentModel.DataAnnotations;
using Cod3rsGrowth.Testes.ClassesSingleton;

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
            Assert.Contains("O Id inserido é inválido.", mensagemDeErro.Message);
        }
    }
}