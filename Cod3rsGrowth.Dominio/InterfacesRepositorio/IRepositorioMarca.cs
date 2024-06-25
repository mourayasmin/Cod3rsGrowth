using Cod3rsGrowth.Dominio.Filtros;
using System.Collections.Generic;

namespace Cod3rsGrowth.Dominio.InterfacesRepositorio
{
    public interface IRepositorioMarca
    {
        public Marca Criar(Marca marca);
        public Marca ObterPorId(int id);
        public Marca Atualizar(Marca marca);
        public void Deletar(int id);
        public List<Marca> ObterTodas(FiltrosMarca filtros);
    }
}