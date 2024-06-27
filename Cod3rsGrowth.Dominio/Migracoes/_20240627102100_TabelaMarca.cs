using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migracoes
{
    [Migration(20240627102100)]
    public class _20240627102100_TabelaMarca : Migration
    {
        public override void Up()
    {
            Create.Table("Marca")
                .WithColumn("Id").AsInt32().ForeignKey().Identity()
                .WithColumn("Nome").AsString().Nullable()
                .WithColumn("CNPJ").AsString().Unique().Nullable()
                .WithColumn("Email").AsString().Nullable()
                .WithColumn("Telefone").AsString().NotNullable();
        }

    public override void Down()
    {
        Delete.Table("Marca");
    }
    public void AlterTable()
    {
            Alter.Table("Marca")
                .AlterColumn("CNPJ")
                .AsInt32()
                .Nullable();
    }
    }
}
