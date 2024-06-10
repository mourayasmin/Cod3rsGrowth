using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Testes.ClassesSingleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Cod3rsGrowth.Testes.RepositoriosMock
{
    public class RepositorioMarcaMock : IRepositorioMarca
    {
        public void Criar(Marca marca)
        {
            throw new NotImplementedException();
        }
        public Marca ObterPorId(int Id)
        {
            foreach (var marca in SingletonMarca.Instancia)
            {
                if (marca.Id == Id)
                {
                    return marca;
                }
            }
            return null;
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
            List<Marca> _repositoriomarca = SingletonMarca.Instancia;
            return _repositoriomarca;
        }
    }
}
