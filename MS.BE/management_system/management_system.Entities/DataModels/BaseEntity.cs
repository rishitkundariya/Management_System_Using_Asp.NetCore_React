using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_system.Entities.DataModels
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public long UpdatedBy {  get; set; }
    }
}
