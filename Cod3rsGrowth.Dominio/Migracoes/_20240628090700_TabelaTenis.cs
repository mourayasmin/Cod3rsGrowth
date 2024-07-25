using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migracoes
{
    [Migration(20240628090700)]
    public class _20240628090700_TabelaTenis : Migration
    {
        public override void Up()
        {
            Create.Table("Tenis")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable().Unique()
                .WithColumn("IdMarca").AsInt32().NotNullable()
                .WithColumn("Nome").AsString().Nullable()
                .WithColumn("Linha").AsInt32().Nullable()
                .WithColumn("Preço").AsDouble().Nullable()
                .WithColumn("Avaliação").AsDecimal().Nullable()
                .WithColumn("Lançamento").AsDateTime().NotNullable()
                .WithColumn("Disponibilidade").AsBoolean().NotNullable();
            Create.ForeignKey("Idmarca").FromTable("Tenis").ForeignColumn("Idmarca").ToTable("Marca").PrimaryColumn("Id");

        }

        public override void Down()
        {
            Delete.Table("Tenis");
        }
    }
}
