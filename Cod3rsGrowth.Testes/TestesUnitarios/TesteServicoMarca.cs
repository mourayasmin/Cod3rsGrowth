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
        private ServicoMarca _servicoMarca;
        public TesteServicoMarca()
        {
            _servicoMarca = ProviderService?.GetService<ServicoMarca>();
            SingletonMarca.Instancia.Clear();
        }

        [Fact]
        public void deve_obter_lista_de_marcas_cadastradas()
        {
            SingletonMarca.Instancia.AddRange(new List<Marca> { new Marca(), new Marca() });
            var listaDeMarcas = _servicoMarca.ObterTodas();
            Assert.NotNull(listaDeMarcas);
            const int quantidadeDeMarcasNaLista = 2;
            Assert.Equal(quantidadeDeMarcasNaLista, listaDeMarcas.Count);
        }

        [Fact]
        public void deve_retornar_marca_atraves_do_id_de_marca_informado()
        {
            var marca = new Marca
            {
                Id = 1111,
                Nome = "Adidas do Brasil LTDA",
                Telefone = "1155463700",
            };

            SingletonMarca.Instancia.Add(marca);
            var marcaRetornada = _servicoMarca.ObterPorId(marca.Id);

            Assert.NotNull(marcaRetornada);
            Assert.Equal(marca.Id, marcaRetornada.Id);
            Assert.Equal(marca.Nome, marcaRetornada.Nome);
            Assert.Equal(marca.Telefone, marcaRetornada.Telefone);
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
                Telefone = "1158963256",
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
                Cnpj = cnpj,
                Email = "oxerbrasil@oxer.com.br",
                Nome = "Oxer do Brasil LTDA",
                Telefone = "1158963256",
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
                Telefone = "1158963256",
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
                Nome = nome,
                Cnpj = "65498732132165",
                Email = "oxerbrasil@oxer.com.br",
                Telefone = "1158963256",
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
                Email = email,
                Cnpj = "65498732132165",
                Telefone = "1158963256",
                Id = 6666
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoMarca.Criar(marcaCriada));
            Assert.Contains("Informe um e-mail válido.", mensagemDeErro.Message);
        }

        [Fact]
        public void deve_retornar_marca_editada_com_sucesso()
        {
            var marcaASerAtualizada = new Marca()
            {
                Cnpj = "42274696002561",
                Email = "contato@adidasbrasil.com.br",
                Nome = "Adidas do Brasil LTDA",
                Telefone = "1158963256",
                Id = 1111
            };
            SingletonMarca.Instancia.Add(marcaASerAtualizada);
            var marcaRetornada = new Marca()
            {
                Cnpj = "42274696002561",
                Email = "contato@adidasbr.com.br",
                Nome = "Adidas do Brasil LTDA",
                Telefone = "1158963289",
                Id = 1111
            };
            marcaASerAtualizada = _servicoMarca.Atualizar(marcaRetornada);
            Assert.Equivalent(marcaRetornada, marcaASerAtualizada);
        }

        [Fact]
        public void deve_retornar_erro_por_email_editado_nulo()
        {
            var marcaAtualizada = new Marca()
            {
                Cnpj = "42274696002561",
                Email = null,
                Nome = "Adidas do Brasil LTDA",
                Telefone = "1158963256",
                Id = 1111
            };
            var mensagemDeErro = Assert.Throws<ValidationException>(() => _servicoMarca.Atualizar(marcaAtualizada));
            Assert.Contains("Informe um e-mail válido.", mensagemDeErro.Message);
        }

        [Fact]
        public void deve_retornar_erro_por_marca_nula()
        {
            Marca marcaAtualizada = null;
            var mensagemDeErro = Assert.Throws<Exception>(() => _servicoMarca.Atualizar(marcaAtualizada));
            Assert.Contains("A marca não foi informada.", mensagemDeErro.Message);
        }

        [Fact]
        public void deve_remover_marca_com_sucesso()
        {
            var marcaASerDeletada = new Marca()
            {
                Cnpj = "42274696002561",
                Email = "empresarial@adidas.com.br",
                Nome = "Adidas do Brasil",
                Telefone = "1158963256",
                Id = 7984
            };
            _servicoMarca.Deletar(marcaASerDeletada.Id);
            var marcaParaDeletar = SingletonMarca.Instancia.Find(marca => marca.Id == marcaASerDeletada.Id);
            Assert.Null(marcaParaDeletar);
        }
    }
}