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
    public class EmployeeTerritoryRepository : GenericRepository<EmployeeTerritory>, IEmployeeTerritoryRepository
    {
        public EmployeeTerritoryRepository(DbContext context) : base(context)
        {

        }

        public IQueryable<EmployeeTerritory> GetTotalReport()
        {
            return dbset.AsQueryable<EmployeeTerritory>();
        }
    }
}
