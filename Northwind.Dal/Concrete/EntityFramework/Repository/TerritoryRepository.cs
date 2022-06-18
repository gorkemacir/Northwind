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
    public class TerritoryRepository : GenericRepository<Territory>, ITerritoryRepository
    {
        public TerritoryRepository(DbContext context) : base(context)
        {

        }
        public IQueryable<Territory> GetTotalReport()
        {
            return dbset.AsQueryable<Territory>();
        }
    }
}
