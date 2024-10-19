using management_system.Entities.DataModels;
using management_system.Repository.interfaces;
using management_system.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_system.Repository.Reposotories
{
    public class BrandRepository : GenericRepository<Brand> , IBrandRepository
    {
        public BrandRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
