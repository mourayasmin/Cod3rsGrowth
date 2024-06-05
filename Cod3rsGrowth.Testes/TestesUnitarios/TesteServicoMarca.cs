using Cod3rsGrowth.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.Configuracoes;
using Cod3rsGrowth.Servicos.InterfacesServicos;

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
    }
}