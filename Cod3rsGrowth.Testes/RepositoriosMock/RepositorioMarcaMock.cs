using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Testes.ClassesSingleton;

namespace Cod3rsGrowth.Testes.RepositoriosMock
{
    public class RepositorioMarcaMock : IRepositorioMarca
    {
        public Marca Criar(Marca marca)
        {
            SingletonMarca.marcas.Add(marca);
            return marca;
        }

        public Marca ObterPorId(int id)
        {
            return SingletonMarca.Instancia.FirstOrDefault(marca => marca.Id == id);
        }

        public Marca Atualizar(Marca marca)
        {
            var marcaEditada = ObterPorId(marca.Id);
            marcaEditada.Email = marca.Email;
            marcaEditada.Telefone = marca.Telefone;
            return marcaEditada;
        }

        public void Deletar(int id)
        {
            Marca marcaParaDeletar = ObterPorId(id);
            SingletonMarca.marcas.Remove(marcaParaDeletar);
        }

        public List<Marca> ObterTodas(FiltrosMarca filtros)
        {
            List<Marca> _repositoriomarca = SingletonMarca.Instancia;
            return _repositoriomarca;
        }
    }
}