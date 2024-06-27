using LinqToDB.Data;
using LinqToDB.Mapping;

[Table("Marca")]
    public class Marca
    {
    [PrimaryKey]
        public int Id { get; set; }

    [Column("Nome")]
        public string? Nome { get; set; }

    [Column("CNPJ"), NotNull]
        public string? Cnpj { get; set; }

    [Column("Email")]
        public string? Email { get; set; }

    [Column("Telefone"), NotNull]   
        public int Telefone { get; set; }
    }