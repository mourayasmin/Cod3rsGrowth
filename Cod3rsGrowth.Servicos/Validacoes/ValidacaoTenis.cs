using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio;

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
                .LessThanOrEqualTo(20000.00)
                .WithMessage("O preço informado é inválido. O limite de preço é 20000.")
                .GreaterThan(0)
                .WithMessage("O preço informado é inválido.");
            RuleFor(tenis => tenis.Avaliacao)
                .GreaterThan(0)
                .WithMessage("A avaliação informada é inválida. Informe uma avaliação de 0 a 10.")
                .LessThanOrEqualTo(10)
                .WithMessage("A avaliação informada é inválida. Informe uma avaliação de 0 a 10.");
            RuleFor(tenis => tenis.Nome)
                .NotNull()
                .WithMessage("Informe o nome da marca.")
                .NotEmpty()
                .WithMessage("Informe o nome da marca.");
        }
    }
}
