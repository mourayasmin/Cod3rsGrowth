using FluentValidation;

namespace Cod3rsGrowth.Servicos.Validacoes
{
    public class ValidacaoTenis : AbstractValidator<Tenis>
    {
        public ValidacaoTenis()
        {
            RuleFor(tenis => tenis.Linha)
                .NotNull()
                .WithMessage("Informe o nome da linha.");
            RuleFor(tenis => tenis.Preco)
                .NotNull()
                .WithMessage("Informe o preço do produto.")
                .GreaterThan(0)
                .WithMessage("O preço informado é inválido.");
            RuleFor(tenis => tenis.Avaliacao)
                .GreaterThanOrEqualTo(0)
                .WithMessage("A avaliação informada é inválida. Informe uma avaliação de 0 a 10.")
                .LessThanOrEqualTo(10)
                .WithMessage("A avaliação informada é inválida. Informe uma avaliação de 0 a 10.");
            RuleFor(tenis => tenis.Nome)
                .NotNull()
                .WithMessage("O nome do tênis está vazio.")
                .NotEmpty()
                .WithMessage("O nome do tênis está vazio.");
        }
    }
}