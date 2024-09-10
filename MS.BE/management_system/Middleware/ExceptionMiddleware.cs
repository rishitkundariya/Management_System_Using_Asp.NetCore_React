using management_system.Shared.Exceptions;
using management_system.Shared.Utilities;

namespace management_system.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }
        private static Task HandleException(HttpContext context, Exception ex)
        {
            APIResponse errorResponse = new()
            {
                IsSuccess = false
            };
            switch (ex)
            {
                case NotFoundException _:
                    errorResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                    errorResponse.ErrorMessages=ex.Message;
                    break;
                case BadRequestException _:
                case EntityNullException _:
                    errorResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    errorResponse.ErrorMessages=ex.Message;
                    break;
                case UnauthorizedException _:
                    errorResponse.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                    errorResponse.ErrorMessages=ex.Message;
                    break;
                default:
                    errorResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    errorResponse.ErrorMessages=ex.Message;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)errorResponse.StatusCode;
            return context.Response.WriteAsync(errorResponse.ToString());
        }

    }
}
