using FluentValidation;
using management_system.Shared.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace management_system.Filters
{
    public class ModelValidatorFilter<TDto>: IActionFilter  where TDto : class
    {
        private IValidator<TDto> _validator;

        public ModelValidatorFilter(IValidator<TDto> validator)
        {
            _validator = validator;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };
            var argument = context.ActionArguments.Values.OfType<TDto>().FirstOrDefault();

            if (argument != null)
            {
                var validationResult = _validator.Validate(argument);
                if (!validationResult.IsValid)
                {
                    response.ErrorMessages = validationResult.Errors.Select(e => new { e.PropertyName, Message=e.ErrorMessage });
                    context.Result = new BadRequestObjectResult(response);
                }
            }
            else
            {
                context.Result = new BadRequestObjectResult(response);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
