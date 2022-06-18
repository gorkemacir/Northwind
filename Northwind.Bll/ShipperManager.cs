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
    public class ShipperManager<T, TDto> : GenericManager<Shipper, DtoShipper>, IShipperService
    {
        public ShipperManager(IServiceProvider service) : base(service)
        {
        }

        public IQueryable<DtoShipper> GetTotalReport()
        {
            throw new NotImplementedException();
        }
    }
}
