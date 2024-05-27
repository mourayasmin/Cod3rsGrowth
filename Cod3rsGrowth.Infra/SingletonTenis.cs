using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Infra
{
    public sealed class SingletonTenis
    {
        private static SingletonTenis _instanceTenis; //campo privado para armazenamento da instância
        public string Value { get; set; }
        private static readonly object _lock = new object();
        public static SingletonTenis GetInstance(string value) // método de criação público estático; chamar o construtor(?)
        {
            if (_instanceTenis == null)
            {
                lock (_lock) {
                    if (_instanceTenis == null) {
                        _instanceTenis = new SingletonTenis(); // cria o objeto; campo estático(?)
                        _instanceTenis.Value = value;
                    }
                }
            }
            return _instanceTenis;
        }
    }
}
