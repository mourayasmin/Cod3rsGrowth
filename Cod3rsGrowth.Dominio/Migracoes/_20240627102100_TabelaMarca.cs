using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migracoes
{
    [Migration(20240627102100)]
    public class _20240627102100_TabelaMarca : Migration
    {
        public override void Up()
        {
            Create.Table("Marca")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().Nullable()
                .WithColumn("CNPJ's").AsString().Unique().Nullable()
                .WithColumn("Email").AsString().Nullable()
                .WithColumn("Telefone").AsString().NotNullable()
                .WithColumn("DataDeCriacao").AsDateTime().Nullable();
        }
        public override void Down()
        {
            Delete.Table("Marca");
        }
    }
}
