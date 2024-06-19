using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Testes.ClassesSingleton;
using Cod3rsGrowth.Testes.Configuracoes;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.TestesUnitarios
{
    public class TesteServicoMarca : TesteBase
    {
        protected ServicoMarca _servicoMarca;
        public TesteServicoMarca()
        {
            _servicoMarca = ProviderService?.GetService<ServicoMarca>();
        }

        [Fact]
        public void deve_obter_lista_de_marcas_cadastradas()
        {
            var listaDeMarcas = _servicoMarca.ObterTodas();
            Assert.NotNull(listaDeMarcas);
            Assert.Equal(5, listaDeMarcas.Count);
        }

        [Fact]
        public void deve_retornar_marca_atraves_do_id_de_marca_informado()
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
        public void deve_retornar_erro_ao_obter_por_id_de_marca_inexistente_(int idMarcaInexistente)
        {
            var mensagemDeErro = Assert.Throws<ArgumentException>(() => _servicoMarca.ObterPorId(idMarcaInexistente));
            Assert.Contains("O Id informado é inválido.", mensagemDeErro.Message);
        }

        [Fact]
        public void deve_retornar_marca_criada()
        {
            var marcaCriada = new Marca()
            {
                Cnpj = "65498732132165",
                Email = "oxerbrasil@oxer.com.br",
                Nome = "Oxer do Brasil LTDA",
                Telefone = 1158963256,
                Id = 6666
            };
            var resultadoMarca = _servicoMarca.Criar(marcaCriada);
            Assert.NotNull(resultadoMarca);
            Assert.Equal(resultadoMarca, marcaCriada);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        public void deve_retornar_erro_por_cnpj_nulo_ou_vazio(string cnpj)
        {
            var marcaCriada = new Marca()
            {
                Email = "oxerbrasil@oxer.com.br",
                Nome = "Oxer do Brasil LTDA",
                Telefone = 1158963256,
                Id = 6666
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoMarca.Criar(marcaCriada));
            Assert.Contains("Informe o CNPJ da marca.", mensagemDeErro.Message);
        }

        [Fact]
        public void deve_retornar_erro_por_cnpj_de_tamanho_errado()
        {
            var marcaCriada = new Marca()
            {
                Cnpj = "654987321321",
                Email = "oxerbrasil@oxer.com.br",
                Nome = "Oxer do Brasil LTDA",
                Telefone = 1158963256,
                Id = 6666
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoMarca.Criar(marcaCriada));
            Assert.Contains("Informe um CNPJ válido.", mensagemDeErro.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        public void deve_retornar_erro_por_nome_nulo_ou_vazio(string nome)
        {
            var marcaCriada = new Marca()
            {
                Cnpj = "65498732132165",
                Email = "oxerbrasil@oxer.com.br",
                Telefone = 1158963256,
                Id = 6666
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoMarca.Criar(marcaCriada));
            Assert.Contains("O nome da marca está vazio.", mensagemDeErro.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        public void deve_retornar_erro_por_email_nulo_ou_vazio(string email)
        {
            var marcaCriada = new Marca()
            {
                Cnpj = "65498732132165",
                Telefone = 1158963256,
                Id = 6666
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoMarca.Criar(marcaCriada));
            Assert.Contains("Informe um e-mail válido.", mensagemDeErro.Message);
        }

        [Fact]
        public void deve_retornar_marca_editada_com_sucesso()
        {
            var marcaAtualizada = new Marca()
            {
                Cnpj = "42274696002561",
                Email = "contato@adidasbrasil.com.br",
                Nome = "Adidas do Brasil LTDA",
                Telefone = 1158963256,
                Id = 1111
            };
            var marcaRetornada = _servicoMarca.Atualizar(marcaAtualizada);
            Assert.Equivalent(marcaRetornada, marcaAtualizada);
        }

        [Fact]
        public void deve_retornar_erro_por_email_editado_nulo()
        {
            var marcaAtualizada = new Marca()
            {
                Cnpj = "42274696002561",
                Email = null,
                Nome = "Adidas do Brasil LTDA",
                Telefone = 1158963256,
                Id = 1111
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoMarca.Atualizar(marcaAtualizada));
            Assert.Contains("Informe um e-mail válido.", mensagemDeErro.Message);
        }

        [Fact]
        public void deve_retornar_erro_por_tenis_nulo()
        {
            Marca marcaAtualizada = null;
            var mensagemDeErro = Assert.Throws<Exception>(() => _servicoMarca.Atualizar(marcaAtualizada));
            Assert.Contains("A marca não foi informada.", mensagemDeErro.Message);
        }

        [Fact]
        public void deve_remover_marca_com_sucesso()
        {
            var idMarcaDeletada = 1111;
            _servicoMarca.Deletar(idMarcaDeletada);
            var marcaParaDeletar = SingletonMarca.Instancia.Find(marca => marca.Id == idMarcaDeletada);
            Assert.Null(marcaParaDeletar);
        }
    }
}