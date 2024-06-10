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
            var idMarca = 2222;
            var resultado = _servicoMarca.ObterPorId(idMarca);
            var marcaEsperada = _servicoMarca.ObterPorId(2222);
            Assert.Equivalent(resultado, marcaEsperada);
        }

        public void Ao_Obter_Por_Id_De_Marca_Inexistente_Deve_Retornar_Exceção()
            {
            var Id = 5698;
            Assert.Throws<ArgumentException>(() => _servicoMarca.ObterPorId(Id));
            }
    }
}