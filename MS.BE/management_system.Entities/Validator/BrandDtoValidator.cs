using FluentValidation;
using management_system.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_system.Entities.Validator
{
    public class BrandDtoValidator : AbstractValidator<BrandDto>
    {
        public BrandDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Brand Name is Required.")
                .NotNull().WithMessage("Brand Name is Required.")
                .MaximumLength(50).WithMessage("Brand Name lenght exceed the 50 character limit!");

            RuleFor(x => x.ShortName).NotEmpty().WithMessage("Brand Short Name is Required.")
               .NotNull().WithMessage("Brand Short Name is Required.")
               .MaximumLength(20).WithMessage("Brand Short Name lenght exceed the 20 character limit!");

        }
    }
}
