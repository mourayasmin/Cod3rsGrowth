using LinqToDB.Data;
using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

[Table("Marca")]
    public class Marca
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Column("CNPJ"), NotNull]
        public string? Cnpj { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("Nome")]
        public string? Nome { get; set; }

        [Column("Telefone"), NotNull]   
        public int Telefone { get; set; }
    }