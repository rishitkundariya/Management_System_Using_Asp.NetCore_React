using management_system.Shared.Constants;
using management_system.Shared.Utilities;

namespace management_system.Helpers
{
    public static class ResponseHelper
    {
        public static APIResponse CreateResponse(object data, string message = MessageConstants.DEFAULT_CREATED_MESSAGE)
        {
            return new()
            {
                StatusCode = (System.Net.HttpStatusCode)StatusCodes.Status201Created,
                IsSuccess = true,
                Data = data,
                Message = message
            };
        }

        public static APIResponse SuccessResponse(object data, string message = MessageConstants.DEFAULT_SUCCESS_MESSAGE)
        {
            return new()
            {
                StatusCode = (System.Net.HttpStatusCode)StatusCodes.Status200OK,
                Data =data,
                IsSuccess = true,
                Message = message
            };
        }
    }
}
