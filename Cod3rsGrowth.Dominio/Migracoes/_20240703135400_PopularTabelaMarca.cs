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
                INSERT INTO Marca (Nome, CNPJ, Email, Telefone, DataDeCriacao) 
                VALUES ('Adidas do Brasil LTDA', '42274696002561', 'comercial@adidasbrasil.com.br', '1155463700', '18/08/1949'),
                       ('Nike do Brasil LTDA', '59546515004555', 'comercial@nikebrasil.com.br', '1150399711', '25/01/1964'),
                       ('Vans Do Brasil LTDA', '07900208007704', 'comercial@vansbrasil.com.br', '1156482955', '16/03/1966'),
                       ('New Balance do Brasil LTDA', '45075049000141', 'comercial@newbalance.com.br', '1123949704', '02/02/1906'),
                       ('Puma Sports LTDA', '05406034002229', 'vendas@pumabrasil.com.br', '1135896478', '18/08/1948'),
                       ('Asics America Corporation', '08416135000144', 'empresarial@asicsbrasil', '1112659874', '21/07/1977');"
            );
        }
        public override void Down() {
            Execute.Sql(@"
                DELETE FROM Marca 
                WHERE Nome IN (
                    'Adidas do Brasil LTDA', 
                    'Nike do Brasil LTDA', 
                    'Vans do Brasil LTDA', 
                    'New Balance do Brasil do LTDA',
                    'Puma Sports LTDA'),
                    'Asics America Corporation');"
            );
        }
    }
}