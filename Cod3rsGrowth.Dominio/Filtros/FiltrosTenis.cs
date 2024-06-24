using Cod3rsGrowth.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cod3rsGrowth.Dominio.Filtros
{
    public class FiltrosTenis
    {
        public string? Nome { get; set; }
        public DateTime? Lancamento { get; set; }
        public double Preco { get; set; }
        public LinhaEnum? Linha { get; set; }
    }
}
