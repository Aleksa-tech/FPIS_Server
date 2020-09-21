using FluentValidation;
using FPIS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.Infrastructure.Validation
{
    public class KlijentValidator : AbstractValidator<Klijent>
    {
        public KlijentValidator()
        {
            RuleFor(client => client.PIB).NotNull().NotEmpty().WithMessage("PIB mora biti unijet!");
            RuleFor(client => client.AdresaISediste).NotNull().NotEmpty().WithMessage("Adresa i sediste mora biti unijeta!");
        }
    }
}
