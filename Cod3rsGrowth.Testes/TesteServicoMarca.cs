using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes
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