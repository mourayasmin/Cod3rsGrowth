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
                .WithMessage("A linha informada é inválida.");
            RuleFor(tenis => tenis.Preco)
                .NotNull()
                .WithMessage("O preço informado é inválido.")
                .NotEmpty()
                .WithMessage("O preço informado é inválido.")
                .LessThanOrEqualTo(5000.00)
                .WithMessage("O preço informado é inválido. Informe um preço de 0 a 5000 reais.")
                .GreaterThan(0)
                .WithMessage("O preço informado é inválido. Informe um preço de 0 a 5000 reais.");
            RuleFor(tenis => tenis.Avaliacao)
                .NotNull()
                .WithMessage("A avaliação informada é inválida.")
                .NotEmpty()
                .WithMessage("A avaliação informada é inválida.")
                .GreaterThan(10)
                .WithMessage("A avaliação informada é inválida. Informe uma avaliação de 0 a 10.")
                .LessThanOrEqualTo(0)
                .WithMessage("A avaliação informada é inválida. Informe uma avaliação de 0 a 10.");
            RuleFor(tenis => tenis.Nome)
                .NotNull()
                .WithMessage("O nome informado é inválido.")
                .NotEmpty()
                .WithMessage("O nome informado é inválido.");
        }
    }
}
