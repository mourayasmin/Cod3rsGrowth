using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Testes.ClassesSingleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Testes.RepositoriosMock
{
    public class RepositorioTenisMock : IRepositorioTenis
    {
        public void Criar(Tenis tenis)
        {
            throw new NotImplementedException();
        }
        public Tenis ObterPorId(int Id)
        {
            Id _repositoriotenis = SingletonTenis.Instancia;
            return _repositoriotenis;
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
