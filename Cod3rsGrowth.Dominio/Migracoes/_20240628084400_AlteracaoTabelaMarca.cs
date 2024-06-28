using FluentMigrator;

namespace Cod3rsGrowth.Dominio.Migracoes
{
    [Migration(20240628084400)]
    public class _20240628084400_AlteracaoTabelaMarca : Migration
    {
        public override void Up()
        {
            Rename.Column("CNPJ's").OnTable("Marca").To("CNPJ");
        }

        public override void Down()
        {
            Delete.Table("Marca");
        }
    }
}

