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
        public void Criar();
        public void Ler();
        public void Atualizar();
        public void Deletar();
        public List<Marca> ObterTodas(int Id);
    }
}
