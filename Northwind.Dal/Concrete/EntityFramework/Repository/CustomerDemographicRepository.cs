using Microsoft.EntityFrameworkCore;
using Northwind.Dal.Abstract;
using Northwind.Dal.Concrete.Repository;
using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Concrete.EntityFramework.Repository
{
    public class CustomerDemographicRepository : GenericRepository<CustomerDemographic>, ICustomerDemographicRepository
    {

        public CustomerDemographicRepository(DbContext context) : base(context)
        {

        }
        public IQueryable<CustomerDemographic> GetTotalReport()
        {
            return dbset.AsQueryable<CustomerDemographic>();
        }
    }
}
