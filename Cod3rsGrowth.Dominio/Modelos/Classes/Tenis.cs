using Cod3rsGrowth.Dominio.Enum;
using System;
using LinqToDB.Mapping;

[Table("Tenis")]
    public class Tenis
    {
    [Column("Linha")]
        public LinhaEnum? Linha { get; set; }

    [PrimaryKey]
        public int Id { get; set; }

    [Column("Idmarca")]
        public int Idmarca { get; set; }

    [Column("Preço")]
        public double? Preco { get; set; }

    [Column("Lançamento")]
        public DateTime Lancamento { get; set; }

    [Column("Avaliação")]
        public decimal Avaliacao { get; set; }

    [Column("Nome")]
        public string? Nome { get; set; }

    [Column("Disponibilidade")]
        public bool Disponibilidade { get; set; }
    }