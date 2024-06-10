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
        public void Deve_Retornar_Lista_De_Tenis_Cadastrados()
        {
            var listaDeTenis = _servicoTenis.ObterTodos();
            Assert.NotNull(listaDeTenis);
            Assert.Equal(4, listaDeTenis.Count);
        }

        [Fact]
        public void Deve_Retornar_Tenis_Atraves_Do_Id_Informado()
        {
            var idTenisProcurado = 0001;
            var resultadoTenis = _servicoTenis.ObterPorId(idTenisProcurado);
            var tenisEsperado = _servicoTenis.ObterPorId(0001);
            Assert.Equivalent(resultadoTenis, tenisEsperado);
        }
        [Fact]
        public void Deve_Retornar_Mensagem_De_Erro_Pelo_Id_De_Tenis_Inexistente()
        {
            var Id = 0000;
            Assert.Throws<ArgumentException>(() => _servicoTenis.ObterPorId(Id));
        }
    }
}