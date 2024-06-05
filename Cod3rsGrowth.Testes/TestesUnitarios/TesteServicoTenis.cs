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
        public void Obter_Lista_De_Tenis_Cadastrados()
        {
            var listaDeTenis = _servicoTenis?.ObterTodos();
            Assert.NotNull(listaDeTenis);
            Assert.Equal(4, listaDeTenis.Count);
        }
    }
}