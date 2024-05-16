using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Cod3rsGrowth.Teste;

namespace Cod3rsGrowth.Cod3rsGrowth.Teste
{
    public class TesteBase : IDisposable
    {
        private readonly string NomeDoTenis;

        public TesteBase ()
        {
            NomeDoTenis = string.Empty;
        }
        public string Dispose()
        {
            return NomeDoTenis;
        }
    }
}
