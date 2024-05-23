using Cod3rsGrowth.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Infra
{
    public interface IRepositorioMarca
    {
        string Criar(Marca marca);
        string Ler(Marca marca);
        string Atualizar(Marca marca);
        string Deletar(Marca marca);
        public List<Marca> ObterTodas()
        {
            List<Marca> marca = new List<Marca>();
            return marca;
        }
    }
}
