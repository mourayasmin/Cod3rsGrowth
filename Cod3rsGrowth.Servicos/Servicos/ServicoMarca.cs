using Cod3rsGrowth.Dominio;
using Cod3rsGrowth.Dominio.Enum;
using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using Cod3rsGrowth.Servicos.InterfacesServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Servicos.Servicos
{
    public class ServicoMarca : IServicoMarca
    {
        public ServicoMarca(IRepositorioMarca RepositorioMarcaMock)
        {
            _repositoriomarca = RepositorioMarcaMock;
        }
        private IRepositorioMarca _repositoriomarca;
        public List<Marca> ObterTodas()
        {
            return _repositoriomarca.ObterTodas();
        }
        public Marca ObterPorId(int Id)
        {
            return _repositoriomarca.ObterPorId(Id) ?? throw new ArgumentException("O Id informado é inválido.");
        }
    }
}