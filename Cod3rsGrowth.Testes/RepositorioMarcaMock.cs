using Cod3rsGrowth.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Infra;
using Xunit.Sdk;

namespace Cod3rsGrowth.Testes
{
    public class RepositorioMarcaMock : IRepositorioMarca
    {
        public void Criar(Marca marca)
        {
            throw new NotImplementedException();
        }
        public Marca ObterPorId(int Id)
        {
            throw new NotImplementedException();
        }
        public void Atualizar(Marca marca)
        {
            throw new NotImplementedException();
        }
        public void Deletar(Marca marca)
        {
            throw new NotImplementedException();
        }
        public List<Marca> ObterTodas()
        {
            List<Marca> marca = new List<Marca>();
            return marca;
        }
    }
}
