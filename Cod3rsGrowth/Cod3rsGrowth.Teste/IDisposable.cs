using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Cod3rsGrowth.Teste
{
    public class IDisposable
    {
        protected IServiceProvider ServiceProvider { get; set; }  
        public interface IService
        {
             string GetNome();
        }
    
    }
}
