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
        public DBCod3rsGrowth(DataOptions<DBCod3rsGrowth> options) : base(options.Options) { }

        public ITable<Tenis> Tenis => this.GetTable<Tenis>();
        public ITable<Marca> Marca => this.GetTable<Marca>();
    }
}