using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migracoes
{
    [Migration(20240627103100)]
    public class _20240627103100_TabelaTenis : Migration
    {
        public override void Up()
        {
            Create.Table("Tenis")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable().Unique()
                .WithColumn("Idmarca").AsInt32().ForeignKey().NotNullable().Unique()
                .WithColumn("Nome").AsString().Nullable()
                .WithColumn("Linha").AsInt32().Nullable()
                .WithColumn("Preço").AsDouble().Nullable()
                .WithColumn("Avaliação").AsDecimal().Nullable()
                .WithColumn("Lançamento").AsDateTime().NotNullable()
                .WithColumn("Disponibilidade").AsBoolean().NotNullable();
            Create.ForeignKey("Id").FromTable("Tenis").ForeignColumn("Idmarca").ToTable("Marca").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.Table("Tenis");
        }

        public void AlterTable()
        {
            Alter.Table("Tenis")
                .AlterColumn("Preço")
                .AsDecimal()
                .Nullable();
        }
    }
}
