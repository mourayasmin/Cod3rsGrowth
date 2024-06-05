using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Testes
{
    public class RepositorioTenisMock : IRepositorioTenis
    {
        public void Criar(Tenis tenis)
        {
            throw new NotImplementedException();
        }
        public Tenis ObterPorId(int Id)
        {
            throw new NotImplementedException();
        }
        public void Atualizar(Tenis tenis)
        {
            throw new NotImplementedException();
        }
        public void Deletar(Tenis tenis)
        {
            throw new NotImplementedException();
        }
        public List<Tenis> ObterTodos()
        {
            List<Tenis> _repositoriotenis = SingletonTenis.Instancia;
            return _repositoriotenis;
        }
    }
}
