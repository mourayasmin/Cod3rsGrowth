using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Dominio.Filtros;
using System.Collections.Generic;
using LinqToDB;
using System.Linq;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioTenis : IRepositorioTenis
    {
        private readonly DBCod3rsGrowth _db;
        public RepositorioTenis(DBCod3rsGrowth db)
        {
            _db = db;
        }
        public List<Tenis> ObterTodos(FiltrosTenis? filtros)
        {
            IQueryable<Tenis> query = _db.Tenis.AsQueryable();
            if (filtros != null)
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

                if (filtros.Preco != null && filtros.Preco != 0)
                {
                    query = query.Where(x => x.Preco == filtros.Preco);
                }

                if (filtros.Lancamento != null)
                {
                    query = query.Where(x => x.Lancamento == filtros.Lancamento);
                }

                if(filtros.IdMarca != null)
                {
                    query = query.Where(x => x.IdMarca == filtros.IdMarca);
                }
            }

            return query.ToList();
        }

        public Tenis Criar(Tenis tenis)
        {
            tenis.Id = _db.InsertWithInt32Identity(tenis);
            return tenis;
        }

        public Tenis ObterPorId(int id)
        {
            var tenis = _db.Tenis.FirstOrDefault(x => x.Id == id);
            return tenis;
        }

        public Tenis Atualizar(Tenis tenis)
        {
            _db.Update(tenis);
            return tenis;
        }

        public void Deletar(int id)
        {
            var tenis = _db.Tenis.FirstOrDefault(x => x.Id == id);
            _db.Delete(tenis);
        }
    }
}