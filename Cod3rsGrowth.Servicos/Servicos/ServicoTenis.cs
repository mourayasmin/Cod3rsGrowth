using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Enum;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Servicos.InterfacesServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Servicos.Servicos
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
        public int ObterPorId(int Id)
        {
            foreach (var Id in List<Tenis>) 
            {
                    if(Id.List<Tenis> == Id) { //como ter acesso a idTenisProcurado se 
                    //o servico nao tem acesso ao teste?
                         Id = _repositoriotenis;
                    }
            }
         return _repositoriotenis.ObterPorId(int Id);

        }
    }
}