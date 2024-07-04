using LinqToDB.Data;
using LinqToDB.Mapping;

[Table("Marca")]
public class Marca
{
    [Column("Id")]
    public int Id { get; set; }

    [Column("Nome")]
    public string? Nome { get; set; }

    [Column("CNPJ"), NotNull]
    public string? Cnpj { get; set; }

    [Column("Email")]
    public string? Email { get; set; }

    [Column("Telefone"), NotNull]
    public string Telefone { get; set; }
}