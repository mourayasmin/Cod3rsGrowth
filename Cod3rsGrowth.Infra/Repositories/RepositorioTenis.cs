using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Filtros;
using System;
using System.Collections.Generic;
using System.Text;
using Cod3rsGrowth.Dominio.Enum;
using LinqToDB.SqlQuery;
using LinqToDB.Data;
using LinqToDB;
using System.Linq;
using static LinqToDB.Common.Configuration;

namespace Cod3rsGrowth.Infra.Repositories
{
    public class RepositorioTenis : IRepositorioTenis
    {
        List<Tenis> IRepositorioTenis.ObterTodos(FiltrosTenis? filtros = null)
        {
            using (var _db = new DataConnection())
            {
                using var db = new DBCod3rsGrowth();
                IQueryable<Tenis> query = db.Tenis.AsQueryable();
                if(filtros != null)
                {
                    if (filtros.Disponibilidade && filtros.Disponibilidade != null)
                    {
                        query = query.Where(x => x.Disponibilidade == true);
                    }
                    if (filtros.Linha != null)
                    {
                        query = query.Where(x => x.Linha == filtros.Linha);
                    }
                    if (filtros.Nome != null)
                    {
                        query = query.Where(x => x.Nome == filtros.Nome);
                    }
                    if (filtros.Preco != null)
                    {
                        query = query.Where(x => x.Preco == filtros.Preco);
                    }
                    if (filtros.Lancamento != null)
                    {
                        query = query.Where(x => x.Lancamento == filtros.Lancamento);
                    }
                }

                return query.ToList();
            }
        }

        Tenis IRepositorioTenis.Criar(Tenis tenis)
        {
            throw new NotImplementedException();
        }

        Tenis IRepositorioTenis.ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        Tenis IRepositorioTenis.Atualizar(Tenis tenis)
        {
            throw new NotImplementedException();
        }

        void IRepositorioTenis.Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}