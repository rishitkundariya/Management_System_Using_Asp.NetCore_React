using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_system.Shared.Constants
{
    public class MessageConstants
    {
        public const string RECORD_NOT_FOUND = "Record not exist.";
        public const string DEFAULT_SUCCESS_MESSAGE = "Success";
        public const string DEFAULT_CREATED_MESSAGE = "Record created successfully.";
        public const string ID_VALIDATION_MESSAGE = "Id must be greater than 0.";

        #region Brand 
        public const string BRAND_CREATED_MESSAGE = "Brand Record created successfully.";
        public const string BRAND_UPDATED_MESSAGE = "Brand Record updated successfully.";
        public const string BRAND_DELETED_MESSAGE = "Brand Record deleted successfully.";
        #endregion Brand


    }
}
