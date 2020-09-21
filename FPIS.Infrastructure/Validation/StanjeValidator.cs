using FluentValidation;
using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Infrastructure.Validation
{
    public class StanjeValidator : AbstractValidator<Stanje>
    {
        public StanjeValidator()
        {
            RuleFor(accBalance => accBalance.IznosStanja).NotNull().NotEmpty().WithMessage("Iznos stanja mora biti unijet!");
        }
    }
}
