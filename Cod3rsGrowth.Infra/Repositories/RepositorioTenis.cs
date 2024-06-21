using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using Cod3rsGrowth.Dominio.Enum;
using LinqToDB.SqlQuery;
using LinqToDB.Data;

namespace Cod3rsGrowth.Infra.Repositories
{
    public class RepositorioTenis : IRepositorioTenis
    {
        private readonly DBCod3rsGrowth _db;

        List<Tenis> IRepositorioTenis.ObterTodos()
        {
            throw new NotImplementedException();
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