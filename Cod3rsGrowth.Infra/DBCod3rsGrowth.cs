using LinqToDB;
using LinqToDB.Data;
using Cod3rsGrowth.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cod3rsGrowth.Infra
{
    public class DBCod3rsGrowth : DataConnection
    {
        public DBCod3rsGrowth(DataOptions options) : base(options) { }

        public ITable<Tenis> Tenis => this.GetTable<Tenis>();
        public ITable<Marca> Marca => this.GetTable<Marca>();
    }
}