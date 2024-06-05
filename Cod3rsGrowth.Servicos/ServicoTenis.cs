using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Enum;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Servicos
{
    public class ServicoTenis : IServicoTenis
    {
        public ServicoTenis(IRepositorioTenis RepositorioTenisMock) 
        {
            _repositoriotenis = RepositorioTenisMock;
        }
        private IRepositorioTenis _repositoriotenis;
        public List<Tenis> ObterTodos()
        {
            return _repositoriotenis.ObterTodos();
        }
    }
}