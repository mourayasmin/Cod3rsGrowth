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

        string Criar(Tenis tenis);
        string Ler(Tenis tenis); 
        string Atualizar(Tenis tenis);
        string Deletar(Tenis tenis);

        public List<Tenis> ObterTodos()
        {
            List <Tenis> tenis = new List <Tenis>();
            return tenis;
        }
    }
}
