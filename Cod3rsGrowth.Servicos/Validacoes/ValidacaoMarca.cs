using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio;

namespace Cod3rsGrowth.Servicos.Validacoes
{
    public class ValidacaoMarca : AbstractValidator<Marca>
    {
        public ValidacaoMarca() 
        {
            RuleFor(marca => marca.Cnpj)
                .NotNull()
                .WithMessage("Informe o CNPJ da marca.")
                .NotEmpty()
                .WithMessage("Informe o CNPJ da marca.");
            RuleFor(marca => marca.Nome)
                .NotNull()
                .WithMessage("Informe o nome da marca.")
                .NotEmpty()
                .WithMessage("Informe o nome da marca.");
            RuleFor(marca => marca.Id)
                .NotNull()
                .WithMessage("Informe o Id da marca.");
        }
    }
}
