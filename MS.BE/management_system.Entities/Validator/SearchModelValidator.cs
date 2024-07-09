using FluentValidation;
using management_system.Shared.Constants;
using management_system.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_system.Entities.Validator
{
    public class SearchModelValidator : AbstractValidator<SearchModel>
    {
        public SearchModelValidator()
        {
            List<string> shortTyps = new List<string> { SystemConstants.ASCENDING, SystemConstants.DESCENDING };
            RuleFor(x=>x.PageNo).GreaterThanOrEqualTo(1).WithMessage("Page Number must be greater then 1.");
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1).WithMessage("Page Size must be greater then 1.");
            RuleFor(x => x.SortType).Must(x => shortTyps.Contains(x)).WithMessage("Shorting Type is not valid.");
        }
    }
}