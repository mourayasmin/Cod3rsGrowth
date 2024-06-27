using Cod3rsGrowth.Dominio.Enum;
using System;
using LinqToDB.Data;
using System.ComponentModel.DataAnnotations.Schema;
using LinqToDB.Mapping;

[Table("Tenis")]
    public class Tenis
    {
        public LinhaEnum? Linha { get; set; }
        [PrimaryKey]
        public int Id { get; set; }
        public int Idmarca { get; set; }
        public double? Preco { get; set; }
        public DateTime Lancamento { get; set; }
        public decimal Avaliacao { get; set; }
        public string? Nome { get; set; }
        public bool Disponibilidade { get; set; }
    }