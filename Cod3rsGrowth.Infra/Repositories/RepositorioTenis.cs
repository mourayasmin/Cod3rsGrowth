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
        public List<Tenis> ObterTodos(FiltrosTenis? filtros = null)
        {
            using (var _db = new DBCod3rsGrowth())
            {
                IQueryable<Tenis> query = _db.Tenis.AsQueryable();
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

        public Tenis Criar(Tenis tenis)
        {
            using (var _db = new DBCod3rsGrowth())
            {
                _db.Insert(tenis);
            }
            return tenis;
        }

        public Tenis ObterPorId(int id)
        {
            Tenis tenis;
            using (var _db = new DBCod3rsGrowth())
            {
                tenis = _db.Tenis.Where(x => x.Id == id).FirstOrDefault();
            }
            return tenis;
        }

        public Tenis Atualizar(Tenis tenis)
        {
            using (var _db = new DBCod3rsGrowth())
            {
                _db.Update(tenis);
            }
            return tenis;
        }

        public void Deletar(int id)
        {
            using (var _db = new DBCod3rsGrowth())
            {
                var tenis = _db.Tenis.Where(x => x.Id == id);
                _db.Delete(tenis);
            }
        }
    }
}