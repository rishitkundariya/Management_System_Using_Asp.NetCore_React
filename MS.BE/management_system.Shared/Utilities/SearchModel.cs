using management_system.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_system.Shared.Utilities
{
    public class SearchModel
    {
        public string? SortBy { get; set; }

        public string SortType { get; set; } = SystemConstants.ASCENDING;

        public int PageNo { get; set; } = 1;

        public int PageSize { get; set; } = SystemConstants.DefaultPageSize;

        public string? FilterField_1 { get; set; }

        public string? FilterField_2 { get; set; }

        public string? FilterField_3 { get; set; }

        public string? FilterField_4 { get; set; }

        public string? FilterField_5 { get; set; }

        public string? FilterField_6 { get; set; }

        public string? FilterField_7 { get; set; }
    }

}
