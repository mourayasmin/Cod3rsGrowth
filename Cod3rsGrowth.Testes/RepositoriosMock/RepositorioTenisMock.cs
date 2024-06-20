using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Testes.ClassesSingleton;

namespace Cod3rsGrowth.Testes.RepositoriosMock
{
    public class RepositorioTenisMock : IRepositorioTenis
    {
        public Tenis Criar(Tenis tenis)
        {
            SingletonTenis.tenis.Add(tenis);
            return tenis;
        }

        public Tenis ObterPorId(int id)
        {
            return SingletonTenis.Instancia.FirstOrDefault(tenis => tenis.Id == id);
        }

        public Tenis Atualizar(Tenis tenis)
        {
            var tenisParaEditar = ObterPorId(tenis.Id);
            tenisParaEditar.Disponibilidade = tenis.Disponibilidade;
            tenisParaEditar.Avaliacao = tenis.Avaliacao;
            tenisParaEditar.Preco = tenis.Preco;
            return tenisParaEditar;
        }

        public void Deletar(int id)
        {
            Tenis tenisParaDeletar = ObterPorId(id);
            SingletonTenis.tenis.Remove(tenisParaDeletar);
        }

        public List<Tenis> ObterTodos()
        {
            List<Tenis> _repositoriotenis = SingletonTenis.Instancia;
            return _repositoriotenis;
        }
    }
}
