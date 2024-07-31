using System.Collections.Generic;
using System.Linq;
using Cod3rsGrowth.Dominio.Filtros;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using LinqToDB;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioMarca : IRepositorioMarca
    {
        private readonly DBCod3rsGrowth _db;
        public RepositorioMarca(DBCod3rsGrowth db)
        {
            _db = db;
        }

        public List<Marca> ObterTodas(FiltrosMarca? filtros = null)
        {
            IQueryable<Marca> query = _db.Marca.AsQueryable();
            if (filtros != null)
            {
                if (filtros.Nome != null)
                {
                    query = query.Where(x => x.Nome.Contains(filtros.Nome));
                }

                if(filtros.DataDeInicio != null && filtros.DataDeFim != null)
                {
                    query = query.Where(marca => marca.DataDeCriacao >= filtros.DataDeInicio && marca.DataDeCriacao <= filtros.DataDeFim);
                }
            }

            return query.ToList();
        }

        public Marca Criar(Marca marca)
        {
            marca.Id = _db.InsertWithInt32Identity(marca);
            return marca;
        }

        public Marca ObterPorId(int id)
        {
            var marca = _db.Marca.FirstOrDefault(x => x.Id == id);
            return marca;
        }

        public Marca Atualizar(Marca marca)
        {
            _db.Update(marca);
            return marca;
        }

        public void Deletar(int id)
        {
            var marca = _db.Marca.FirstOrDefault(x => x.Id == id);
            _db.Delete(marca);
        }
    }
}