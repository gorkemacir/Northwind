using Microsoft.EntityFrameworkCore;
using Northwind.Dal.Abstract;
using Northwind.Dal.Concrete.Repository;
using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Concrete.Entityframework.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {

        }

        public IQueryable<Customer> GetTotalReport()
        {
            return dbset.AsQueryable<Customer>();
        }
    }
}