using System;
using System.Collections.Generic;
using System.Linq;
using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using LinqToDB.Data;

namespace Cod3rsGrowth.Infra.Repositories
{
    public class RepositorioMarca : IRepositorioMarca
    {
        List<Marca> IRepositorioMarca.ObterTodas(FiltrosMarca? filtros = null)
        {
            using (var _db = new DataConnection())
            {
                using var db = new DBCod3rsGrowth();
                IQueryable<Marca> query = db.Marca.AsQueryable();
                if (filtros != null)
                {
                    if (filtros.Nome != null)
                    {
                        query = query.Where(x => x.Nome == filtros.Nome);
                    }
                }
                return query.ToList();
            }
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