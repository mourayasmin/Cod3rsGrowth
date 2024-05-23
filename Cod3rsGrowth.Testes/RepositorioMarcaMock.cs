using Cod3rsGrowth.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Infra;

namespace Cod3rsGrowth.Testes
{
    public class RepositorioMarcaMock : IRepositorioMarca
    {
        public string Criar(Marca marca)
        {
            throw new NotImplementedException();
        }
        public string Ler(Marca marca)
        {
            throw new NotImplementedException();
        }
        public string Atualizar(Marca marca)
        {
            throw new NotImplementedException();
        }
        public string Deletar(Marca marca)
        {
            throw new NotImplementedException();
        }
        public List<Marca> ObterTodos(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
