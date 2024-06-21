using LinqToDB;
using Cod3rsGrowth.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cod3rsGrowth.Infra
{
    public class DBCod3rsGrowth : LinqToDB.Data.DataConnection
    {
        public DBCod3rsGrowth() : base("Cod3rsGrowth") { }

        public ITable<Tenis> Tenis => this.GetTable<Tenis>();
        public ITable<Marca> Marca => this.GetTable<Marca>();
    }
}