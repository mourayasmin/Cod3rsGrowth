using System.Collections.Generic;

namespace Cod3rsGrowth.Dominio.InterfacesRepositorio
{
    public interface IRepositorioTenis
    {
        Tenis Criar(Tenis tenis);
        Tenis ObterPorId(int id);
        Tenis Atualizar(Tenis tenis);
        void Deletar(int id);
        List<Tenis> ObterTodos();
    }
}
