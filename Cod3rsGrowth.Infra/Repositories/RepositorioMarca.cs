using System;
using System.Collections.Generic;
using System.Linq;
using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositories
{
    public class RepositorioMarca : IRepositorioMarca
    {
        public List<Marca> ObterTodas(FiltrosMarca? filtros = null)
        {
            using (var _db = new DBCod3rsGrowth())
            {
                IQueryable<Marca> query = _db.Marca.AsQueryable();
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

        public Marca Criar(Marca marca)
        {
            using (var _db = new DBCod3rsGrowth())
            {
                _db.Insert(marca);
            }
            return marca;
        }

        public Marca ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Marca Atualizar(Marca marca)
        {
            using (var _db = new DBCod3rsGrowth())
            {
                _db.Update(marca);
            }
            return marca;
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}