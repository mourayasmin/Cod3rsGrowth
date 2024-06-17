using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Testes.ClassesSingleton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Cod3rsGrowth.Testes.RepositoriosMock
{
    public class RepositorioMarcaMock : IRepositorioMarca
    {
        public Marca Criar(Marca marca)
        {
            SingletonMarca.marcas.Add(marca);
            return marca;
        }
        public Marca ObterPorId(int Id)
        {
            return SingletonMarca.Instancia.FirstOrDefault(marca => marca.Id == Id);
        }
        public Marca Atualizar(Marca marca)
        {
            var marcaEditada = ObterPorId(marca.Id);
            marcaEditada.Email = marca.Email;
            marcaEditada.Telefone = marca.Telefone;
            return marcaEditada;
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
