using Cod3rsGrowth.Dominio.InterfacesRepositorio;
using FluentValidation;

namespace Cod3rsGrowth.Servicos.Validacoes
{
    public class ValidacaoMarca : AbstractValidator<Marca>
    {
        private readonly IRepositorioMarca _repositorioMarca;
        public ValidacaoMarca()
        {
            RuleFor(marca => marca.Cnpj)
                .NotNull()
                .WithMessage("Informe o CNPJ da marca.")
                .NotEmpty()
                .WithMessage("Informe o CNPJ da marca.")
                .Length(14)
                .WithMessage("Informe um CNPJ válido.")
                .Matches("^\\d+$")
                .WithMessage("Informe um CNPJ válido.");
            RuleFor(marca => marca.Nome)
                .NotNull()
                .WithMessage("O nome da marca está vazio.")
                .NotEmpty()
                .WithMessage("O nome da marca está vazio.");
            RuleFor(marca => marca.Email)
                .NotNull()
                .WithMessage("Informe um e-mail válido.")
                .NotEmpty()
                .WithMessage("Informe um e-mail válido.");
            RuleFor(marca => marca.Telefone)
                .Length(11)
                .Matches("^\\d+$")
                .WithMessage("Informe um telefone válido.");
            RuleFor(marca => marca.Email)
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
                .WithMessage("Insira um e-mail válido.");
        }

        public void ValidacaoDeCNPJJaExistente()
        {
            
        }
    } 
}