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
        public void Criar()
        {
            throw new NotImplementedException();
        }
        public void Ler()
        {
            throw new NotImplementedException();
        }
        public void Atualizar()
        {
            throw new NotImplementedException();
        }
        public void Deletar()
        {
            throw new NotImplementedException();
        }
        public List<Tenis> ObterTodos(int Id)
        {
            List<Tenis> tenis = new List<Tenis>();
            return tenis;
        }
    }
}
