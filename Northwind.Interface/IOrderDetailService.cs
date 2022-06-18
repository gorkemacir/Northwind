using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Interface
{
    public interface IOrderDetailService : IGenericService<OrderDetail, DtoOrderDetail>
    {
        IQueryable<DtoOrderDetail> GetTotalReport();
    }
}
