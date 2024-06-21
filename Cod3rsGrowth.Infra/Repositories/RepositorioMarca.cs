using System;
using System.Collections.Generic;
using System.Text;
using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;

namespace Cod3rsGrowth.Infra.Repositories
{
    public class RepositorioMarca : IRepositorioMarca
    {
        private readonly DBCod3rsGrowth _db;

        List<Marca> IRepositorioMarca.ObterTodas()
        {
            throw new NotImplementedException();
        }

        Marca IRepositorioMarca.Criar(Marca marca)
        {
            throw new NotImplementedException();
        }

        Marca IRepositorioMarca.ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        Marca IRepositorioMarca.Atualizar(Marca marca)
        {
            throw new NotImplementedException();
        }

        void IRepositorioMarca.Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}