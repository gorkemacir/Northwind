using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bll
{
    public class SupplierManager<T, TDto> : GenericManager<Supplier, DtoSupplier>, ISupplierService
    {
        public SupplierManager(IServiceProvider service) : base(service)
        {
        }

        public IQueryable<DtoSupplier> GetTotalReport()
        {
            throw new NotImplementedException();
        }
    }
}
