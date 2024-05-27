using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Infra
{
    public sealed class SingletonMarca
    {
        private SingletonMarca() { }
        private static SingletonMarca _instanceMarca;
        private static readonly object _lock = new object();
        public static SingletonMarca GetInstance(string value)
        {
            if (_instanceMarca == null)
            {
                lock (_lock)
                {
                    if (_instanceMarca == null)
                    {
                        _instanceMarca = new SingletonMarca();
                        _instanceMarca.Value = value;
                    }
                }
            }
            return _instanceMarca;
        }
        public string Value { get; set; }
    }
 }
