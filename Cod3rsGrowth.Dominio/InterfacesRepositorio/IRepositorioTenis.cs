using Cod3rsGrowth.Dominio.Filtros;
using System;
using System.Collections.Generic;

namespace Cod3rsGrowth.Dominio.InterfacesRepositorio
{
    public interface IRepositorioTenis
    {
        public Tenis Criar(Tenis tenis);
        public Tenis ObterPorId(int id);
        public Tenis Atualizar(Tenis tenis);
        public void Deletar(int id);
        public List<Tenis> ObterTodos(FiltrosTenis? filtros = null);
    }
}