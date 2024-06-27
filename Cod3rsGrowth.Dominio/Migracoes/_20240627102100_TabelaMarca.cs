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
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("Nome").AsString()
            .WithColumn("Endereco").AsString()
            .WithColumn("CNPJ").AsString()
            .WithColumn("E-mail").AsString()
            .WithColumn("Telefone").AsString();
    }

    public override void Down()
    {
        Delete.Table("Marca");
    }
    }
}
