using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio.Enum;

namespace Cod3rsGrowth.Dominio
{
    public class Tenis
    {
        public LinhaEnum Linha { get; set; }
        public int Id { get; set; }
        public int Idmarca { get; set; }
        public double Preco { get; set; }
        public DateTime Lancamento { get; set; }
        public decimal Avaliacao { get; set; }
        public string Nome { get; set; }
        public bool Disponibilidade { get; set; }
    }
}
