using Cod3rsGrowth.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Infra
{
    public interface IRepositorioTenis
    {

        public void Criar(Tenis tenis);
        public Tenis ObterPorId(int Id); 
        public void Atualizar(Tenis tenis);
        public void Deletar(Tenis tenis);
        public List<Tenis> ObterTodos();
    }
}
