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
        private readonly DBCod3rsGrowth _db;
        List<Tenis> IRepositorioTenis.ObterTodos(FiltrosTenis? filtros = null)
        {
            IQueryable<Tenis> query = _db.Tenis.AsQueryable();
            if (filtros?.Linha != null) 

            { query = query.Where (tenis => tenis.Linha == LinhaEnum.Casual)


                    // return. ToList(); return final
            }
            
                
            {
                //consertar obtenção da linha; from, select
                ObterTodos(filtros).Where(tenis => x.Linha == linha).ToList();

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