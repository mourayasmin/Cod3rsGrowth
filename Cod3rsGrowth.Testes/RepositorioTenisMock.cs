using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Testes
{
    public class RepositorioTenisMock : IRepositorioTenis
    {
        public string Criar(Tenis tenis)
        {
            throw new NotImplementedException();
        }
        public string Ler(Tenis tenis)
        {
            throw new NotImplementedException();
        }
        public string Atualizar(Tenis tenis)
        {
            throw new NotImplementedException();
        }
        public string Deletar(Tenis tenis)
        {
            throw new NotImplementedException();
        }
        public List<Tenis> ObterTodos(int Id)
        {
            throw new NotImplementedException(); 
        }
    }
}
