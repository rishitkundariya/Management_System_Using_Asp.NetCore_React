using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_system.Shared.Constants
{
    public class SystemConstants
    {
        public const string CONNECTION_STRING = "DefaultConnection";
        public const string HttpStatusMessageSuccess = "Success";
        public const string HttpStatusMessageUnauthorized = "Unauthorized";
        public const string HttpStatusMessageRecordNotFound = "Record Not Found";
        public const string HttpStatusMessageRecordAlreadyExist = "Record Already Exist";
        public const string HttpStatusMessageInternalServerError = "Internal server error";

        public const string InvalidCredentials = "Invalid username or password";
        public const string NoRecordsFound = "No records found";

        public const int DefaultPageSize = 10;
        public const string ASCENDING = "ASC";
        public const string DESCENDING = "DESC";
    }
}
