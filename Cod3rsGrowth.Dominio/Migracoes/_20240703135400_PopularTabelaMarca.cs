using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cod3rsGrowth.Dominio.Migracoes
{
    [Migration(20240703135400)]
    public class _20240703135400_PopularTabelaMarca : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                INSERT INTO Marca (Nome, CNPJ, Email, Telefone) 
                VALUES ('Adidas do Brasil LTDA', '42274696002561', 'comercial@adidasbrasil.com.br', 1155463700);"
            );
        }
        public override void Down() {
            Execute.Sql(@"
                DELETE FROM Marca 
                WHERE nome IN (
                    'Adidas do Brasil LTDA', 
                                    
);"
            );

        }
    }
}