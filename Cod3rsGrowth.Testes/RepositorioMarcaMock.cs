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
        public List<Marca> ObterTodas(int Id)
        {
            List<Marca> marca = new List<Marca>();
            return marca;
        }
    }
}
