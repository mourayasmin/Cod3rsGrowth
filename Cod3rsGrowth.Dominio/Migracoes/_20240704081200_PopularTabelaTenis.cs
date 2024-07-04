using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cod3rsGrowth.Dominio.Migracoes
{
    [Migration(20240704081200)]
    public class _20240704081200_PopularTabelaTenis : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
        INSERT INTO Tenis (Idmarca, Nome, Linha, Preço, Avaliação, Lançamento, Disponibilidade)
        VALUES (1, 'Streetball', 1, 549.99, 8.9, '27/03/2020', 1),
               (2, 'Alphafly 2', 3, 1899.99, 9.2, '02/04/2023', 1),
               (3, 'Knu Skool', 2, 599.99, 9.0, '14/01/2024', 1),
               (4, 'New Balance 550', 1, 999.99, 9.5, '12/05/2021', 1),
               (1, 'Ultraboost', 3, 899.99, 10.0, '10/05/2016', 0),
               (5, 'Puma Suede', 1, 499.99, 8.7, '04/02/2002', 1),
               (1, 'Pharrell Williams HU', 1, 399.99, 9.0, '17/01/2018', 1),
               (3, 'Vans Ultrarange', 0, 599.99, 7.0, '20/07/2020', 1),
               (6, 'Asics Japan S', 1, 399.99, 9.4, '13/06/2022', 1),
               (5, 'Puma RBD Game Low', 1, 499.99, 5.0, '10/03/2023', 0),
               (2, 'Nike Full Force Low', 1, 699.99, 8.0, '05/09/2020', 0);"
            );
        }
        public override void Down()
        {
            Execute.Sql(@"
        DELETE FROM Tenis
        WHERE Nome IN (
                'Streetball',
                'Alphafly 2',
                'Knu Skool',
                'New Balance 550',
                'Ultraboost'),
                'Puma Suede',
                'Pharrell Williams HU'
                'Vans Ultrarange',
                'Asics Japan S',
                'Puma RBD Game Low',
                'Nike Full Force Low';"
                );
        }
    }
}
