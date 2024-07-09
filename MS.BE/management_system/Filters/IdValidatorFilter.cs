using management_system.Shared.Constants;
using management_system.Shared.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace management_system.Filters
{
    public class IdValidatorFilter : ActionFilterAttribute
    {
       override public void OnActionExecuting(ActionExecutingContext context)
       {

            long Id = (long) context.ActionArguments["Id"];
            if (Id <= 0) {
                APIResponse response = new() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };
                response.ErrorMessages = MessageConstants.ID_VALIDATION_MESSAGE;
                context.Result = new BadRequestObjectResult(response);
            }

       }
       override public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
