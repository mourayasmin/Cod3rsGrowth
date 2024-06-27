using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migracoes
{
    public class _20242706103100_TabelaTenis : Migration
    {
        public override void Up()
        {
            Create.Table("Tenis")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity().NotNullable()
                .WithColumn("Idmarca").AsInt32().NotNullable()
                .WithColumn("Nome").AsString().Nullable()
                .WithColumn("Linha").AsInt32().Nullable()
                .WithColumn("Preco").AsDouble().Nullable()
                .WithColumn("Avaliacao").AsDecimal().Nullable()
                .WithColumn("Lancamento").AsDateTime().NotNullable()
                .WithColumn("Disponibilidade").AsBoolean().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Tenis");
        }
    }
}
